using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotControeller : MonoBehaviour
{
    private const string AXIS_VERTICAL = "Vertical";
    private const string PARAM_SPEED = "Speed";
    
    private readonly int _speedId = Animator.StringToHash(PARAM_SPEED);
    
    private Animator _animator;

    private void Awake()
    {
        CacheAnimator();
    }

    private void Update()
    {
        SendSpeed();
    }

    private void CacheAnimator()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void SendSpeed()
    {
        float speed = Input.GetAxis(AXIS_VERTICAL);
        _animator.SetFloat(_speedId, speed);
    }
    
}
