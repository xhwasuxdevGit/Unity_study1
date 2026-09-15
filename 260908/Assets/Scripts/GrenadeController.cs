using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
   [SerializeField] private GameObject _grenadePrefab;
   [SerializeField] private Transform _grenadeSpwanPoint;
   
   [SerializeField] private float _keyChargeTime;
   [SerializeField] private int _maxGrenadeCount;

   public event Action<int> OnGrenadeCountChanged;
   
   public int GrenadeCounter
   {
      get => _grenadeCouter;

      private set
      {
         _grenadeCouter = value;
         OnGrenadeCountChanged?.Invoke(_grenadeCouter);
      }
   }

   private float _throwupForce = 10;
   private float _throwForwardForce = 25.0f; 
   private float _keydownTimer;
   private int _grenadeCouter;

   private bool _isPressedKey => Input.GetKey(KeyCode.Alpha3);
   private bool _isKeyup => Input.GetKeyUp(KeyCode.Alpha3);
   //----------------------------------------------
   private void Start()
   {
      GrenadeCounter = _maxGrenadeCount;
   }

   private void Update()
   {
      ReadInput();
   }
   //-------------------------------------------------

   private void ReadInput()
   {
 
     StartCoroutine(InputkeyRoutine());
   }

   public IEnumerator InputkeyRoutine()
   {
      if (_isPressedKey)
      {
         yield return new WaitForSeconds(_keyChargeTime);
         if (_isKeyup)
         {
            ThrowGrenade();
         }
      }
   }
   
   public void ThrowGrenade()
   {
      GrenadeCounter--;
      if (GrenadeCounter <= 0) return;
      
      GameObject _grenadeInstance = Instantiate(_grenadePrefab,
         _grenadeSpwanPoint.position, _grenadeSpwanPoint.rotation);
      
      Rigidbody _rigidbody = _grenadeInstance.GetComponent<Rigidbody>();
      
      if (_rigidbody == null) return;
     
      Vector3 _throwDirection = (_grenadeInstance.transform.forward * _throwForwardForce) 
                                + (_grenadeInstance.transform.up * _throwupForce);
      _rigidbody.AddForce(_throwDirection);
    
   }
   
   
}
