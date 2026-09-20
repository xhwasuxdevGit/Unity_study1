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

   private float _throwupForce = 7.5f;
   private float _throwForwardForce = 15; 
   private float _keydownTimer;
   private int _grenadeCouter;
   private Coroutine _inputCoroutine;

   private bool _isKeyDown => Input.GetKeyDown(KeyCode.Alpha3);
   private bool _isKeyUp => Input.GetKeyUp(KeyCode.Alpha3);
   private bool _iskeyCharging => Input.GetKey(KeyCode.Alpha3);
   private bool _isGrenadeEnough => GrenadeCounter > 0;
   private bool _isInputWorking;
   
   //----------------------------------------------
   private void Start()
   {
      GrenadeCounter = _maxGrenadeCount;
      _isInputWorking = false;
   }

   private void Update()
   {
      ReadInput();
   }
   //-------------------------------------------------

   private void ReadInput()
   {
      if (_isInputWorking) return;

      if (_isKeyDown && _isGrenadeEnough)
      {
         _inputCoroutine = StartCoroutine(KeyChargeRoutine());
      }

      if (_isKeyUp)
      {
         ThrowGrenade();
         StopCoroutine(_inputCoroutine);
         _inputCoroutine = null;
         _isInputWorking = false;
      }
      
   }

   public IEnumerator KeyChargeRoutine()
   {
      _isInputWorking = true;
      while (_iskeyCharging)
      {
         yield return new WaitForSeconds(_keyChargeTime);
      }
      _isInputWorking = false;
   }
   
   public void ThrowGrenade()
   {
      if (!_isGrenadeEnough) return;
      GrenadeCounter--;
      GameObject _grenadeInstance = Instantiate(_grenadePrefab,
         _grenadeSpwanPoint.position, _grenadeSpwanPoint.rotation);
      
      Rigidbody _rigidbody = _grenadeInstance.GetComponent<Rigidbody>();
      
      if (_rigidbody == null) return;
     
      Vector3 _throwDirection = (_grenadeInstance.transform.forward * _throwForwardForce) 
                                + (_grenadeInstance.transform.up * _throwupForce);
      _rigidbody.AddForce(_throwDirection);
    
   }
   
   
}
