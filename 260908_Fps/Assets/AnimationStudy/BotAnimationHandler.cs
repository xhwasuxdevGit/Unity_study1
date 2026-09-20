using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationHandler : MonoBehaviour
{
    [SerializeField] private string _moveXPram;
    [SerializeField] private string _moveZPram;

    private BotController _controller;
    private Animator _animator;
    private int _moveX;
    private int _moveZ;
    
    //-------------------------------------------
    private void Awake()
    {
        CacheComponents();
        Init();
    }
    private void OnEnable() => BindBotEvents();
    private void OnDisable() => UnbildBotEvents();
    //---------------------------------------------

    private void Init()
    {
        _moveX = Animator.StringToHash(_moveXPram);
        _moveZ = Animator.StringToHash(_moveZPram);
    }
    
    private void CacheComponents()
    {
        _controller = GetComponent<BotController>();
        _animator = GetComponent<Animator>();
    }
    
    private void BindBotEvents()
    {
        _controller.OnMove += SetMoveAnim;
    }
    
    private void UnbildBotEvents()
    {
        _controller.OnMove -= SetMoveAnim;
    }

    private void SetMoveAnim(Vector2 movement)
    {
        _animator.SetFloat(_moveX, movement.x);
        _animator.SetFloat(_moveZ, movement.y);
    }
}
