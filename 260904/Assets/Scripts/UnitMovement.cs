using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
   // 1. 목적지를 받기
   // 2. 목적지가 정해져있으면 그쪽으로 이동하기
   // 3. 목적지에 도착하면 목적지 해제하기.
   

   private Vector4 _destination;
   private bool _isMoving;
   [SerializeField] private float _moveSpeed;

   private void Update()
   {
       Move();
   }

   private void Move()
   {
       if (!_isMoving) return;

       transform.position = Vector3.MoveTowards(
       transform.position,
       _destination,
       _moveSpeed * Time.deltaTime
           );

       if (Vector3.Distance(transform.position, _destination) < 0.1f)
       {
           _isMoving = false;
       }
   }
   
   public void SetDestination(Vector3 destination)
    {
      _destination = destination;
      _isMoving = true;
    }
}
