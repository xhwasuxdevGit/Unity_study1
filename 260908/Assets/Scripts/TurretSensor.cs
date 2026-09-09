using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSensor : MonoBehaviour
{
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] private LayerMask _targetLayer;
    
    private const string LAYER_PLAYER = "Player";
    private Transform _playerTransform;
    private SphereCollider _sphereCollider;

    private bool _isPlayerInTrigger => _playerTransform != null;
    private bool _isPlayerInsight;
    private bool _isAwarePlayer => _isPlayerInsight && _isPlayerInTrigger;

    public Transform PlayerTransform => _playerTransform;
    public bool IsAwarePlayer => _isAwarePlayer;
    public bool IsPlayerInsight => _isPlayerInsight;
    
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            _playerTransform = other.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            _playerTransform = null;
        }
        
    }

    private void Awake()
    {
        CacheComponent();
    }

    private void Update()
    {
        RayShotToPlayer();
    }

    private void CacheComponent()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }
    
    private void RayShotToPlayer()
    {

        _isPlayerInsight = false;
        if(!_isPlayerInTrigger) return;
        
        Vector3 from = new Vector3(transform.position.x,
            _muzzlePoint.position.y,
            transform.position.z);

        Vector3 to = new Vector3(_playerTransform.position.x,
            _muzzlePoint.position.y,
            _playerTransform.position.z);
        
        Ray ray = new Ray(from, (to - from).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _sphereCollider.radius, _targetLayer))
        {
            Debug.Log("플레이어 감지됨");
            _isPlayerInsight = true;
        }
        
    }
}
