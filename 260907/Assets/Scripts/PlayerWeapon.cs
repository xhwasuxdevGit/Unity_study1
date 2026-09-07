using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
  
    // Raycast -> IDamageable

    private Transform _cameraTransform;
    
    [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;

    [SerializeField] private float _range;
    
    [SerializeField] private int _damage;

    [SerializeField] private float _AttackCooldown;
    private bool _isPressdFire => Input.GetKeyDown(_fireKey);
    private float _currentCooldown;
    

    private bool _isReadyToAttack
    {
        get { return _currentCooldown >= _AttackCooldown; }
    }

    private void Awake()
    {
        CacheComponents();
    }
    
    public void Fire()
    {
        if (!_isPressdFire || !_isReadyToAttack) return;
        

        IDamageable damageable = GetDamageable();

        if (damageable == null) return;
        
        damageable.TakeDamage(_damage);
        Debug.Log($"PlayweWeapon: {damageable.GameObject.name}에게 발사");

        _currentCooldown = 0f;
    }

    public void UpdateCurrentCooldown()
    {
        if (_isReadyToAttack) return;
        _currentCooldown += Time.deltaTime;
    }

    private IDamageable GetDamageable()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;
        IDamageable damageable = null;

        if (Physics.Raycast(ray, out hit, _range))
        {
            damageable = hit.transform.GetComponent<IDamageable>();
        }

        return damageable;

    }

    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
    }
    
}
