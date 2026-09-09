using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeObject : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private GameObject _explosionEffect;

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    
    private float _timer;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
