using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   private Rigidbody _rigidbody;
   private Transform _transform;
   private float _keydownTimer;
   private float _throwUpForce = 15.0f; 
   private float _thrwoForwardForce = 10.0f; 
   private Vector3 _throwDirection;

   private void Awake()
   {
      CacheComponents();
   }

   private void Start()
   {
    
   }
   
   private void Update()
   {
      ReadyGrenade();
   }

   private void FixedUpdate()
   {
      ThrowGrenade();
   }

   private void CacheComponents()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _transform = GetComponent<Transform>();
   }
   


   private void ReadyGrenade()
   {
      if (Input.GetKey(KeyCode.Alpha3))
      {
         
         _keydownTimer += Time.deltaTime;
         SetGrenade();
         Debug.Log("GrenadeController: 수류탄 장전중!");
         
      }
      
   }

   private void ThrowGrenade()
   {

      if (_keydownTimer > 3.0f )
      {
         if (Input.GetKeyUp(KeyCode.Alpha3))
         {
            MoveGrenade();
            _keydownTimer = 0.0f;
            Debug.Log("GrenadeController: 수류탄 투척!");
         }
         
      }
      else if (Input.GetKeyDown(KeyCode.Mouse1))
      {
         // 수류탄 장전 초기화
      }
   }

   private void MoveGrenade()
   {
      _rigidbody.isKinematic = false;
      _throwDirection = (Vector3.forward * _thrwoForwardForce) + (Vector3.up * _throwUpForce); 
      _rigidbody.AddForce(_throwDirection);
   
   }

   private void SetGrenade()
   {
      
   }
   
}
