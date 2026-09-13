using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   [SerializeField] private float _grenadeChargeTime;
   [SerializeField] private GameObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   private Rigidbody _rigidbody;
   private float _throwupForce = 3;
   private float _throwForwardForce = 20.0f; 
   private Vector3 _throwDirection;
   
   private float _keydownTimer;
   private bool _isPressedKey => Input.GetKey(KeyCode.Alpha3);
   private bool _isKeyup => Input.GetKeyUp(KeyCode.Alpha3);
   private bool _enoughCharge => _keydownTimer >= _grenadeChargeTime;
   


   private void Update()
   {
      ReadInput();
   }

   private void ReadInput()
   {
      if (_isPressedKey)
      {
         Debug.Log("수류탄 충전중");
         _keydownTimer += Time.deltaTime;
      }

      if (_isKeyup)
      {
         if (_enoughCharge)
         {
            ThrowGrenade();
         }
      }
   }
   
   public void ThrowGrenade()
   {

      GameObject _grenadeInstance = Instantiate(
         _grenadePrefab,
         _grenadeSpwanPoint.position, 
         _grenadeSpwanPoint.rotation
      );

      Debug.Log("수류탄 생성!"); 
      
      _rigidbody = _grenadeInstance.GetComponent<Rigidbody>();
      
      if (_rigidbody == null) 
      {
         Debug.LogWarning("생성된 수류탄에 Rigidbody 컴포넌트가 없습니다!");
         return;
      }
     
      _throwDirection = 
         (_grenadeInstance.transform.forward * _throwForwardForce) 
         + (_grenadeInstance.transform.up * _throwupForce);
     
      _rigidbody.AddForce(_throwDirection);
      Debug.Log("수류탄 던지는 중");
   }
   
   
}
