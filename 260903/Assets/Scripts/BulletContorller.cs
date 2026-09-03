using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContorller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private void Awake()
    {
        Destroy(gameObject, _destroyTime);  // 시간지난 뒤 소멸
    }
    
    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        
    }

    
}
