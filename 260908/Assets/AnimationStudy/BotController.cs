using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public event Action<Vector2> OnMove;

    private Vector2 _prevMovement;
    private void Update()
    {
        SetMove();
    }

    private void SetMove()
    {
        Vector2 movement = GetMovement();
        if (_prevMovement == movement) return;
        
        OnMove?.Invoke(movement);
        _prevMovement = movement;
    }

    private Vector2 GetMovement()
    {
        return new Vector2( Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));
    }
    
}
