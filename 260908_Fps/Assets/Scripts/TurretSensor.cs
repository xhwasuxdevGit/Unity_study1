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
    private WaitForSeconds _nextRayshotWait;
    private Coroutine _detectCoroutine;

    private bool _isPlayerInTrigger => _playerTransform != null;
    private bool _isPlayerInsight;
    private bool _isAwarePlayer => _isPlayerInsight && _isPlayerInTrigger;
    private bool _canRayshot;

    public Transform PlayerTransform => _playerTransform;
    public bool IsAwarePlayer => _isAwarePlayer;
    public bool IsPlayerInsight => _isPlayerInsight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            _playerTransform = other.transform;
            if (_detectCoroutine == null)
            { 
                _detectCoroutine = StartCoroutine(DetectRoutine()); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            _playerTransform = null;
            _isPlayerInsight = false;
            if (_detectCoroutine != null)
            {
                StopCoroutine(_detectCoroutine);
                _detectCoroutine = null;
            }
        }
    }

    private void Awake()
    {
        CacheComponent();
    }

    private void Start()
    {
        _nextRayshotWait = new WaitForSeconds(0.1f);
    }
    

    private void CacheComponent()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }
    
    private IEnumerator DetectRoutine()
    {
        while (_isPlayerInTrigger)
        {
            RayShotToPlayer();
            yield return _nextRayshotWait;
        }
    }
    
    private void RayShotToPlayer()
    {
        _isPlayerInsight = false;
        if (!_isPlayerInTrigger) return;

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
            _isPlayerInsight = true;
        }
    }

}
