using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IPoolable
{
    private int _damage;
    private float _speed;
    private const string LAYER_PLAYER = "Player";
    
    private float _returnToDelay;
    private float _elapsedTime;

    public ObjectPool Pool { get; set; }
    public Transform tr { get => transform; }
   

    // 벽인 경우 -> 파괴
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            // ToDo 데미지 입히기 구현
            Debug.Log("플레이어 데미지 입음");
        }
        
        Pool.Return(this);
    }
    
      private void Update()
      {
          UpdateElapsedTime();
          MoveForward();
          ReturnToPool();
      }
      
    // 총알 앞으로 전진
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    
    public void ReturnToPool()
    {
        if (_elapsedTime >= _returnToDelay)
        {
            _elapsedTime = 0;
            Pool.Return(this);
        }
    }
    

        //터렛으로부터 데이터 전달 받기  
    public void SetData(int damage, float speed, float returToDelay)
    {
        _damage = damage;
        _speed = speed;
        _returnToDelay = returToDelay;
    }

    private void UpdateElapsedTime()
    {
        _elapsedTime += Time.deltaTime;
    }

    
    
    

   
      
      
}
