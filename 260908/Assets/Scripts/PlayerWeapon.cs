using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
  
    // Raycast -> IDamageable

    private Transform _cameraTransform;
    
    [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int SteampackDuration;
    [SerializeField] private FlameObject _flameEffect;
    
    public float AttackCooldown { get { return _attackCooldown; } set { _attackCooldown = value; } }
    
    private float _currentCooldown;
    private int _currentAmmo;
    private bool _isPressedFire => Input.GetKey(_fireKey);
    private bool _isPressdReload => Input.GetKeyDown(_reloadKey);
    private bool _isReadyToAttack
    {
        get { return _currentCooldown >= AttackCooldown; }
    }
    private bool _isEnoughAmmo
    {
       get { return _currentAmmo > 0; }
    }

    private bool _canFire => _isPressedFire && _isReadyToAttack && _isEnoughAmmo;
    
    
    //----------------------------------------------------------------------

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        SetDefault();
    }

    private void Update()
    {
        UpdateCurrentCooldown();
    }

    
    //----------------------------------------------------------------------
    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
        
    }

    private void SetDefault()
    {
        _currentCooldown = 0f;
        _currentAmmo = _maxAmmo;
    }
    
    
    public void Fire()
    {
        if (!_canFire) return;
        
        _currentAmmo--;
        _currentCooldown = 0f;
        PlayFlameobject();
        
        if (!TryGetDamageable(out IDamageable damageable)) return;
        
        damageable.TakeDamage(_damage);
        
        Debug.Log($"PlayweWeapon: {damageable.GameObject.name}에게 발사");
        Debug.Log($"PlayerWeapon: 남은 총알: {_currentAmmo}");
        
    }

    private void PlayFlameobject()
    {
        _flameEffect.gameObject.SetActive(true);
        _flameEffect.Play();
    }

    private void PlaybulletImpactEffect(RaycastHit hit)
    {
        Transform effectTransform = Instantiate(_flameEffect).transform;
        effectTransform.position = hit.point;
        effectTransform.forward = hit.normal;
        effectTransform.gameObject.SetActive(true);

    }

    private bool TryGetDamageable(out IDamageable damageable)
    {
        bool result = false;
        damageable = null;

        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _range))
        {
            PlaybulletImpactEffect(hit);
            result = hit.transform.TryGetComponent(out damageable);
        }
        
        return result;

    }

    public void UpdateCurrentCooldown()
    {
        if (_isReadyToAttack) return;
        _currentCooldown += Time.deltaTime;
    }

    public void AmmoReload()
    {
        if (!_isPressdReload) return;
        {
            Debug.Log("PlayerWeapon: 재장전 중");
            _currentAmmo = _maxAmmo;
        }
        
    }


    
}
