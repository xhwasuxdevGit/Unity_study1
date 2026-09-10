using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _headTransform;
    [SerializeField] private Transform _muzzlePoint;
   
    [Header("Bullet")] 
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestoryDelay;
    
    private TurretSensor _turretSensor;
    private float _currentCooldown;
    
    private bool _isReadyToFire { get { return _currentCooldown >= _cooldown; } }

    private void Awake()
    {
        CacheComponent();
    }
    private void Update()
    {
        UpdateCurrentCooldown();
        Rotate();
        Fire();
    }
    //------------------------------------------------------------

    private void CacheComponent()
    {
        _turretSensor = GetComponentInChildren<TurretSensor>();
    }

    private void Fire()
    {
        if (!_turretSensor.IsAwarePlayer) return;
        
        Vector3 look = new Vector3(_turretSensor.PlayerTransform.position.x,
            _headTransform.position.y,
            _turretSensor.PlayerTransform.position.z);
        
        _headTransform.LookAt(look);

        if (!_isReadyToFire) return;
        
        SpawnBullet();

        _currentCooldown = 0f;

    }

    private void UpdateCurrentCooldown()
    {
        if (_isReadyToFire) return;
        _currentCooldown += Time.deltaTime;
    }

    private void SpawnBullet()
    {
        // 프리팹
        // Instantiate 하면서 position, rotation 설정 까지
        BulletController bullet = Instantiate(_bulletPrefab,
            _muzzlePoint.position,
            _muzzlePoint.rotation);
        
        bullet.SetData(_bulletDamage, _bulletDamage, _bulletDestoryDelay);

    }
    
    private void Rotate()
    {
        if (_turretSensor.IsPlayerInsight) return;
        
        _headTransform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
    

}