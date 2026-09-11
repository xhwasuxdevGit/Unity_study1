using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   
   // 수류탄 자체를 플레이어에 붙이고 붙어있는 수류탄 프리팹의 폭발 애니메이션을 재생해야함
   // 지금은 던져진 수류탄이 아니라 플레이어 붙어있는 폭발 애니메이션이 재생되고 있음
   [SerializeField] private float _explosionDelay;
   [SerializeField] private GameObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   private Rigidbody _rigidbody;
   private float _throwupForce = 20.0f;
   private float _throwForwardForce = 30.0f; 
   private Vector3 _throwDirection;
   private GameObject _grenadeInstance;
   private float _timer;
   private ExplosionObject _explosionObject;

   private void Awake()
   {
   
   }
   private void Update()
   {
      TimeCount();
   }

   private void TimeCount()
   {
      _timer += Time.deltaTime;
   }
   
   public void ThrowGrenade()
   {
      Debug.Log("GrenadeController: 수류탄 투척!!");
      SpwanGrenade();
      MoveGrenade();
      
   }

   private void MoveGrenade()
   {
     Debug.Log("수류탄 움직이는 중");
     
     _throwDirection = 
        (_grenadeInstance.transform.forward * _throwForwardForce) 
        + (_grenadeInstance.transform.up * _throwupForce) ;
     
      _rigidbody.AddForce(_throwDirection);
      SetTimer();
   
   }

   private void SpwanGrenade()
   {
      _grenadeInstance = Instantiate(_grenadePrefab,
         _grenadeSpwanPoint.position,
         _grenadeSpwanPoint.transform.rotation);
      _rigidbody = _grenadeInstance.GetComponent<Rigidbody>();
      _explosionObject = _grenadeInstance.GetComponentInChildren<ExplosionObject>();
      
      Debug.Log("수류탄 생성!");   
   }

   private void SetTimer()
   {
     if( _grenadeInstance == null) return;
     
      if (_timer >= _explosionDelay )
      {
         _explosionObject.gameObject.SetActive(true);
         Destroy(_grenadeInstance, _explosionDelay);
      }
   }
   
}
