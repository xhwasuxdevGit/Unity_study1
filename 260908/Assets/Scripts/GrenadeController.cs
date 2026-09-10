using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   [SerializeField] private Transform _grenadeSpwanPoint;
   [SerializeField] private float _explosionDelay;
   [SerializeField] private GameObject _explosionEffect;
   [SerializeField] private PlayerController _player;
   private Rigidbody _rigidbody;
   private float _throwUpForce = 15.0f; 
   private float _thrwoForwardForce = 10.0f; 
   private Vector3 _throwDirection;
   

   private void Awake()
   {
      CacheCompoments();
   }

   private void CacheCompoments()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _player = GetComponent<PlayerController>();
   }
   
   public void ThrowGrenade()
   {
      if (_player.ReadyInput)
      {
         SpwanGrenade();
         MoveGrenade();
         Debug.Log("GrenadeController: 수류탄 던지기 실행중!");
      }
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
         _grenadeSpwanPoint.transform.position,
         _grenadeSpwanPoint.transform.rotation);
      Debug.Log("수류탄 생성!");   
   }

   private void SetTimer()
   {
      Destroy(gameObject, _explosionDelay);
   }



}
