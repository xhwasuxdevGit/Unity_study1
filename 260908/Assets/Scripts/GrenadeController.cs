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
   private float _throwForwardForce = 20; 
   private float _keydownTimer;
   private int _grenadeCouter;
   private Coroutine _inputCoroutine;

   private bool _isPressedKey => Input.GetKeyDown(KeyCode.Alpha3);
   private bool _isKeyUp => Input.GetKeyUp(KeyCode.Alpha3);
   private bool _isGrenadeEnough => GrenadeCounter > 0;
   private bool _isInputReady;
   
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
      if (_isPressedKey && !_isInputReady && _isGrenadeEnough)
      {
         StartCoroutine(KeyChargeRoutine());
      }
      
   }

   public IEnumerator KeyChargeRoutine()
   {
      _isInputReady = true;
      yield return new WaitForSeconds(_keyChargeTime);
      if (_isKeyUp)
      {
         ThrowGrenade();
      }
      
      _isInputReady = false;
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
