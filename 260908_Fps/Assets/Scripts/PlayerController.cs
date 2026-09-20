using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInteractor, IDamageable
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _detectionRange;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private int _maxHp;
    
    private PlayerMovement _movement;
    private PlayerWeapon _weapon;
    private Transform _cameraTransform;
    private IInteractable _targetInteractable;
    private int _currentHp;
    
    private bool _hasDetectInteractable => _targetInteractable != null;
    private bool _isPressedInteractKey => Input.GetKeyDown(_interactionKey);
    private bool _canInteraction => _hasDetectInteractable && _isPressedInteractKey;
    
    public GameObject GameObject { get => gameObject; }
    public event Action<int> OnPlayerHPChanged;

    public int CurrentHp
    {
        get => _currentHp;

        set
        {
            _currentHp = value;
            OnPlayerHPChanged?.Invoke(_currentHp);
        }
    }
    
    //-------------------------------------------------------
    private void Awake()
    {
        CacheComponents();
        
    }

    private void Start()
    {
        CurrentHp = _maxHp;
    }

    private void FixedUpdate()
    {
        _movement.Move();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameRunning) return;
        
        _movement.Rotate();
        _weapon.Fire();
        _weapon.Reload();
        DetectInteractable();
        TryInteract();
        
        if(Input.GetKeyDown(KeyCode.P)) GameManager.Instance.Pause();
        else if (Input.GetKeyDown(KeyCode.O)) GameManager.Instance.Run();
    }

    private void LateUpdate()
    {
        SetCameraTransform();
        SetWeaponTransform();
    }
    //-----------------------------------------------------------

    private void CacheComponents()
    {
        _movement = GetComponent<PlayerMovement>();
        _weapon = GetComponentInChildren<PlayerWeapon>();
        _cameraTransform = Camera.main.transform;
        CurrentHp = _maxHp;
    }

    private void SetWeaponTransform()
    {
        _weapon.transform.SetPositionAndRotation(
            _cameraPivot.position,
            _cameraPivot.rotation );
    }

    private void SetCameraTransform()
    {
        _cameraTransform.SetPositionAndRotation(
            _cameraPivot.position, 
            _cameraPivot.rotation);
    }

    public void DetectInteractable()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, _detectionRange))
        {
            if (_hasDetectInteractable)
            {
                _targetInteractable.Untargeting();
                _targetInteractable = null;
            }
            
            return;
        }
        
        if (_hasDetectInteractable)
        {
            if (hit.collider.gameObject == _targetInteractable.GameObject)
            {
                return; // 돌일한 Interactable을 계속 주시하는 경우
            }
        }
        
        _targetInteractable?.Untargeting();
        _targetInteractable = hit.collider.GetComponent<IInteractable>();
        
        _targetInteractable?.Targeting();

    }
    
    public void TryInteract()
    {
        if (!_canInteraction) return;
        
        _targetInteractable.Interact(this);
        _targetInteractable = null;
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        Debug.Log($"{gameObject}가 데미지 입음  [HP:  {CurrentHp}/{_maxHp}]");
    }

}
