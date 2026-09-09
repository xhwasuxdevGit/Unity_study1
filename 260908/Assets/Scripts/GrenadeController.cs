using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   [SerializeField] private GrenadeObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   
   private float _keydownTimer;
   private float _throwUpForce = 15.0f; 
   private float _thrwoForwardForce = 10.0f; 
   private Vector3 _throwDirection;
  
   
   private void Update()
   {
      ReadyGrenade();
   }

   private void FixedUpdate()
   {
      ThrowGrenade();
   }

   private void ReadyGrenade()
   {
      if (Input.GetKey(KeyCode.Alpha3))
      {
         _keydownTimer += Time.deltaTime;
         
         Debug.Log("GrenadeController: 수류탄 장전중!");
      }
      
   }

   private void ThrowGrenade()
   {
      if (Input.GetKeyUp(KeyCode.Alpha3))
      {
         if (_keydownTimer > 1.0f )
         {
            SpwanGrenade();
            MoveGrenade();
            _keydownTimer = 0.0f;
            Debug.Log("GrenadeController: 수류탄 투척!");
            
         }
      }
      
   }

   private void MoveGrenade()
   {
     Debug.Log("수류탄 움직이는 중");
      _grenadePrefab.Rigidbody.isKinematic = false;
      _throwDirection = (Vector3.forward * _thrwoForwardForce) + (Vector3.up * _throwUpForce); 
      _grenadePrefab.Rigidbody.AddForce(_throwDirection);
      _grenadePrefab.SetTimer();
   
   }

   private void SpwanGrenade()
   {
         Instantiate(_grenadePrefab, 
         _grenadeSpwanPoint.transform.position,
         _grenadeSpwanPoint.transform.rotation);
      Debug.Log("수류탄 생성!");   
   }
   
   

}
