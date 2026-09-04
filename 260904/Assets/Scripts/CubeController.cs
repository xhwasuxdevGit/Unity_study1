using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CubeController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Collision
        // - Enter : 충돌이 시작됐을 때
        // - stay : 충돌이 유지되고 있을 때
        // - Exit : 충돌이 종료됐을 때
        
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"{gameObject.name} : {collision.gameObject.name}랑 충돌했다");
        }

        private void OnCollisionStay(Collision collision)
        {Debug.Log($"{gameObject.name} : {collision.gameObject.name}랑 붙어있음");
           
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"{gameObject.name} : {collision.gameObject.name}랑 떨어짐");
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"데미지 입음: {damage}");
        }


        // Trigger (특정 이벤트의 트리거 역할)
}
