using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInteractor
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _detectionRange;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private int _maxHp;
    [SerializeField] private GrenadeController _grenade;
    private PlayerMovement _movement;
    private PlayerWeapon _weapon;
    private Transform _cameraTransform;
    private IInteractable _targetInteractable;
    private bool _hasDetectInteractable => _targetInteractable != null;
    private bool _isPressedInteractKey => Input.GetKeyDown(_interactionKey);
    private bool _canInteraction => _hasDetectInteractable && _isPressedInteractKey;
    
    public GameObject GameObject { get => gameObject; }
    public int CurrentHp { get; set; }
    
    private float _keydownTimer;
    private bool _isPressedKey => Input.GetKey(KeyCode.Alpha3);
    private bool _isKeyup => Input.GetKeyUp(KeyCode.Alpha3);
    private bool _chargeKey => _keydownTimer > 1.0f;
    private bool _readyInput => _isKeyup && _chargeKey;
    public bool ReadyInput => _readyInput;

    //-------------------------------------------------------
    private void Awake()
    {
        CacheComponents();
        CurrentHp = _maxHp;
    }

    private void Start()
    {
        LockCursor();
    }

    private void FixedUpdate()
    {
        _movement.Move();
        _grenade.ThrowGrenade();
    }

    private void Update()
    {
        _movement.Rotate();
        _weapon.Fire();
        _weapon.AmmoReload();
        DetectInteractable();
        TryInteract();
        ReadyGrenade();
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

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        
        //  위와 동일한 내용 구현
        // _cameraTransform.position = _cameraPivot.position;
        // _cameraTransform.rotation = _cameraPivot.rotation;
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

    public void ReadyGrenade()
    {
        if(!_isPressedKey) return;
        
        if (_isPressedKey)
        {
            _keydownTimer += Time.deltaTime;
            Debug.Log("GrenadeController: 수류탄 장전중!");

            if (_readyInput)
            {
                Debug.Log("GrenadeController: 수류탄 발사!");
                _keydownTimer = 0;
            }
            else
            {
                Debug.Log("GrenadeController: 수류탄 장전완료");
            }
        }
    }
}
