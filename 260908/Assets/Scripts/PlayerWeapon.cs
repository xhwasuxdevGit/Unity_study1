using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeapon : MonoBehaviour
{
    private WaitForSeconds _nextAttackWait;
    private Transform _cameraTransform;
    
    [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _reloadDelay;
    [SerializeField] private int SteampackDuration;
    [SerializeField] private FlameObject _flameEffect;
    [SerializeField] private FlameObject _bulletImpactPrefab;
    
    private int _currentAmmo;
    public event Action<int> OnAmmoChanged;
    public float AttackCooldown { get { return _attackCooldown; } set { _attackCooldown = value; } }

    public int CurrentAmmo
    {
        get => _currentAmmo;
        private set
        {
            _currentAmmo = value;
            OnAmmoChanged?.Invoke(_currentAmmo);
        }
    }
    public int MaxAmmo => _maxAmmo;
    
    private bool _isPressedFire => Input.GetKey(_fireKey);
    private bool _isPressdReload => Input.GetKeyDown(_reloadKey);
  
    private bool _isEnoughAmmo
    {
       get { return CurrentAmmo > 0; }
    }
    private bool _isReloading;
    private bool _isShooting;

    private bool _canFire => _isPressedFire && !_isShooting && 
                             _isEnoughAmmo && !_isReloading;
    
    //----------------------------------------------------------------------

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        SetDefault();
    }
    
    //----------------------------------------------------------------------
    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void SetDefault()
    {
        CurrentAmmo = _maxAmmo;
    }
   
    public void Fire()
    {
        if (!_canFire) return;
        CurrentAmmo--;
        PlayFlameobject();

        if (TryGetDamageable(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
            Debug.Log($"PlayweWeapon: {damageable.GameObject.name}에게 발사");
        }
        
        StartCoroutine(WeaponFireRoutine());
    }
    
    public IEnumerator WeaponFireRoutine()
    {
        _isShooting = true;
        yield return new WaitForSeconds(AttackCooldown);
        _isShooting = false;
    }


    private void PlayFlameobject()
    {
        if (_flameEffect == null) return;
        _flameEffect.Play();
    }

    private void PlaybulletImpactEffect(RaycastHit hit)
    {
        if (_bulletImpactPrefab == null) return;
        
        FlameObject _bulletImpact = Instantiate(_bulletImpactPrefab,
            hit.point, Quaternion.LookRotation(hit.normal));
        
        _bulletImpact.transform.SetParent(hit.transform);
        _bulletImpact.gameObject.SetActive(true);
        _bulletImpact.Play();
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
    
    public void Reload()
    {
        if(_isReloading) return;
        
        if(!_isPressdReload) return;
        
        if (_isPressdReload)
        {
            StartCoroutine(ReloadRoutine());  
        }
        
    }
    
    public IEnumerator ReloadRoutine()
    {
            _isReloading = true;
            yield return new WaitForSeconds(_reloadDelay);
            Debug.Log("PlayerWeapon: 재장전 중");
            CurrentAmmo = _maxAmmo;
            _isReloading = false;
    }
    
}
