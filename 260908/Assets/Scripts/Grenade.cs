using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private GameObject _explosionPrefab;
    private float _timer;

    
    private void Update()
    {
        CountTimer();
    }

  

    private void CountTimer()
    {
        _timer += Time.deltaTime;
        Explode();
    }

    private void Explode()
    {
        if (_explosionPrefab == null) return;
        
        if(_timer >= _explosionDelay )
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
       
    }
    
    
}
