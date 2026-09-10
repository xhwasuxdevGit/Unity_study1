using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   
   [SerializeField] private float _explosionDelay;
   [SerializeField] private GameObject _explosionEffect;
   [SerializeField] private GameObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   
   private Rigidbody _rigidbody;
   private float _throwUpForce = 15.0f; 
   private float _thrwoForwardForce = 10.0f; 
   private Vector3 _throwDirection;
   private PlayerController _playerController;

   private void Awake()
   {
      CacheCompoments();
   }

   private void OnDestroy()
   {
      Explode();
   }

   private void CacheCompoments()
   {
      _rigidbody = _grenadePrefab.GetComponent<Rigidbody>();
   }
   
   public void ThrowGrenade()
   {
      SpwanGrenade();
      MoveGrenade();
      Debug.Log("GrenadeController: 수류탄 던지기 실행중!");
   }

   private void MoveGrenade()
   {
     Debug.Log("수류탄 움직이는 중");
      _rigidbody.isKinematic = false;
      _throwDirection = (Vector3.forward * _thrwoForwardForce) + (Vector3.up * _throwUpForce); 
      _rigidbody.AddForce(_throwDirection);
      SetTimer();
   
   }

   private void SpwanGrenade()
   {
         Instantiate(gameObject,
         _grenadeSpwanPoint.position,
         _grenadeSpwanPoint.transform.rotation);
      Debug.Log("수류탄 생성!");   
   }

   private void SetTimer()
   {
      Destroy(gameObject, _explosionDelay);
   }

   private void Explode()
   {
      // 폭발 애니메이션 적용
      // 인터페이스 활용해서 데미지 입히기
   }



}
