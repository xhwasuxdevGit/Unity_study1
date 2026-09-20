using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledMover : MonoBehaviour
{
   // 1. WASD 이동
   //  - 속도는 인스펙터에서 조절할 수 있도록 노출
   // 2. Player 태그 설정

   [SerializeField] private float _moveSpeed;

   private void Update()
   {
      FieldMove();
   }

   private void FieldMove()
   {
      Vector3 movement = ReadInput().normalized;
      
      transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);
   }
   
   private Vector3 ReadInput()
   {
      return new Vector3(Input.GetAxis("Horizontal"), 0f,
         Input.GetAxis("Vertical"));
   }
   
} 