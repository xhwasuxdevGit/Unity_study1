using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMotionToggle : MonoBehaviour
{
   private const string PARAM_IS_SPINNING = "IsSpinning";
   private const string STATE_CUBE_SPIN = "Base Layer.CubeSpin";

   private Animator _animator;
   private bool _isSpinning;

   private void Awake()
   {
      CacheAnimator();
   }

   private void Update()
   {
      ReadInput();
   }
   
   private void CacheAnimator()
   {
      _animator = GetComponent<Animator>();
   }

   private void ReadInput()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         ToggleMotion();
      }

      if (Input.GetKeyDown(KeyCode.R))
      {
         PlaySpin();
      }
   }

   private void PlaySpin()
   {
      _animator.Play(STATE_CUBE_SPIN);
      Debug.Log("CubeMotionToggle: 회전 상태를 곧바로 재생합니다");
   }

   private void ToggleMotion()
   {
      _isSpinning = !_isSpinning;
      _animator.SetBool(PARAM_IS_SPINNING, _isSpinning);
      Debug.Log($"CubeMotionToggle: 회전 {_isSpinning}");
   }
   
}
