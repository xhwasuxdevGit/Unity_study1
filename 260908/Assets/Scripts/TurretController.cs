using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _headTransform;
    [SerializeField] Transform _muzzlePoint;

    [Header("Bullet")] 
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestoryDelay;
    
    private float _currentCooldown;
    private const string TAG_PLAYER = "Player";
    
    
    private Transform _playerTransform;
    private SphereCollider _sphereCollider;
    private bool _isPlayerInTrigger => _playerTransform != null;
    // _isPlayerInTrigger의 처리를 간소화한 표기(람다식)
    private bool _isPlayerInsight = false;
    private bool _isReadyToFire
    {
        get { return _currentCooldown >= _cooldown; }
    }
    

    private void Awake()    // 람다식 활용 가능 도전해보자
    {
        CacheComponents();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            _playerTransform = other.transform;
            // _isPlayerInTrigger =  true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag(TAG_PLAYER)) { _playerTransform = null; }
        
        
    }

    private void Update()
    {
        UpdateCurrentCooldown();
        RayShotToPlayer();
        Rotate();
        Fire();
    }
    //------------------------------------------------------------
    
    private void CacheComponents()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Fire()
    {
        if (!_isPlayerInsight || !_isPlayerInTrigger) return;
        
        Vector3 look = new Vector3(_playerTransform.position.x,
            _headTransform.position.y,
            _playerTransform.position.z);
        
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

        // SetData
    }
    
    private void Rotate()
    {
        if (_isPlayerInsight) return;
        _headTransform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void RayShotToPlayer()
    {
       _isPlayerInsight = false;
        if (!_isPlayerInTrigger) return;

        Vector3 from = new Vector3(transform.position.x,
            transform.position.y + _muzzlePoint.position.y / 2,
            transform.position.z);

        Vector3 to = new Vector3(_playerTransform.position.x,
            _playerTransform.position.y + _muzzlePoint.position.y / 2,
            _playerTransform.position.z);
        
        Ray ray = new Ray(from, (to - from).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _sphereCollider.radius))
        {
            if (hit.transform.CompareTag(TAG_PLAYER))
            {
                Debug.Log("플레이어 감지됨");
                _isPlayerInsight = true;
            }
         
        }


    }

}