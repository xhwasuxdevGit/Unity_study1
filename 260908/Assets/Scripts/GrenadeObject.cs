using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeObject : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private GameObject _explosionEffect;

    private Transform _transform;
    private float _timer;

    private void Awake()
    {
        
    }

    private void CacheComponents()
    {
        _transform = GetComponent<Transform>();
    }
    

    public void SetTimer()
    {
        _timer = _explosionDelay;
        GrenadeExplode();
    }

    public void GrenadeExplode()
    {
        Destroy(gameObject, _timer);
    }
    
}
