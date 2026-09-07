using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int _damage;
    private float _speed;
    private const string TAG_PLAYER = "Player";
    // 스폰 기준으로 제한시간 이후 파괴
    // 장애물과 충돌할경우
    // 플레이어 -> 데미지를 입히고
    // 벽인 경우 -> 파괴
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            // ToDo 데미지 입히기 구현
            Debug.Log("플레이어 데미지 입음");
        }
        
        Destroy(gameObject);
            
    }
    
      private void Update()
      {
          MoveForward();
      }
      
    // 총알 앞으로 전진
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

        //터렛으로부터 데이터 전달 받기  
        public void SetData(int damage, float speed, float destroyDelay)
      {
          _damage = damage;
          _speed = speed;
          
          Destroy(gameObject, destroyDelay);
      }

   
      
      
}
