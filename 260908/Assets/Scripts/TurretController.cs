using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletpool;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _headTransform;
    [SerializeField] private Transform _muzzlePoint;
   
    [Header("Bullet")] 
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _returnToDelay;
    
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
       // 1. 얻어오기
       IPoolable bullet = _bulletpool.Take();
       
       // 2. TransformPosition, rotation 설정
       bullet.tr.position = _muzzlePoint.position;
       bullet.tr.rotation = _muzzlePoint.rotation;
       
       // 3.활성화
       bullet.tr.gameObject.SetActive(true);
        
        
       
       /*BulletController bullet = Instantiate(_bulletPrefab,
            _muzzlePoint.position,
            _muzzlePoint.rotation);*/
        
        (bullet as BulletController).
            SetData(_bulletDamage, _bulletSpeed, _returnToDelay);

    }
    
    private void Rotate()
    {
        if (_turretSensor.IsPlayerInsight) return;
        
        _headTransform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
    

}