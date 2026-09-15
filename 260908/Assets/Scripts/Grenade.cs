using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _damage;
    private float _timer;
    private bool _isTimerOn;

    private void Start()
    {
        _isTimerOn = false;
    }
    
    private void Update()
    {
        CountTimer();
    }
    private void CountTimer()
    {
        if (_isTimerOn) return;
        
        StartCoroutine(GrenadeTimerRoutine());
    }

    public IEnumerator GrenadeTimerRoutine()
    {
        _isTimerOn = true;
        yield return new WaitForSeconds(_explosionDelay);
        Explode();
        _isTimerOn = false;
    }

    private void Explode()
    {
        if (_explosionPrefab != null)
        {
            GameObject _explosion = Instantiate(_explosionPrefab, 
                transform.position, transform.rotation); 
            Destroy(_explosion, 2.5f);
        }
            GiveDamage(transform.position, 2.5f, _damage);
            Destroy(gameObject);
    }
    
    private void GiveDamage(Vector3 explosionPoint, float radius, int damage)
    {
        Collider[] hitColliders = Physics.OverlapSphere(explosionPoint, radius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }
    
 
    
}
