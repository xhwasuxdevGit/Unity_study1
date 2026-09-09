using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   [SerializeField] private GrenadeObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   
   private Rigidbody _rigidbody;
   private float _keydownTimer;
   private float _throwUpForce = 15.0f; 
   private float _thrwoForwardForce = 10.0f; 
   private Vector3 _throwDirection;
   private GrenadeObject _grenade;
   
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
      _rigidbody = _grenadePrefab.GetComponent<Rigidbody>();
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
      _rigidbody.isKinematic = false;
      _throwDirection = (Vector3.forward * _thrwoForwardForce) + (Vector3.up * _throwUpForce); 
      _rigidbody.AddForce(_throwDirection);
      _grenade.SetTimer();
   
   }

   private void SpwanGrenade()
   {
         _grenade = Instantiate(_grenadePrefab, 
         _grenadeSpwanPoint.transform.position,
         _grenadeSpwanPoint.transform.rotation);
      Debug.Log("수류탄 생성!");   
         
   }
   
   

}
