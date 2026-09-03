using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform  _muzzleTransform;
    [SerializeField] private Transform _playerTansform;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _detectionRange;
    [SerializeField] private float _fireCoolTime;
    private float _elapsed;
    // 총알 생성
      // 총구 위치에
      
    // 효과음 

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _playerTansform.position);

        if (distance <= _detectionRange)
        {
            LookAtPlayer();
            SpawnBullet();
        }
        
        else
        {
            RotateTurret();
        }
        
    }
    
    
    // 플레이어가 특징 거리 밖에 있을땐 회전한다 (타겟 감지)
    // 일정 거리 내에 있을때는 플레이어를 응시한다 (타겟 주시)

    private void RotateTurret()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }

    private void LookAtPlayer()
    {
        transform.LookAt(_playerTansform);
    }

    private void SpawnBullet()
    {
        // 총알생성 쿨타임 만들기 deltatime 누적
        
        _elapsed += Time.deltaTime;
        
        if (_elapsed >= _fireCoolTime)
        {
            Instantiate(
                _bulletPrefab,
                _muzzleTransform.position,
                _muzzleTransform.rotation
                );
            _elapsed = 0;
            /*
             GameObject bullet = Instantiate(_bulletPrefab)
            bullet.transform.position = _muzzleTransform.position;
            bullet.transform.rotation = _muzzleTransform.rotation;
            */
        }
        
        
        
    }
}
