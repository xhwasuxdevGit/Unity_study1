using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Vector4 _destination;
    private bool _isMoving;
    [SerializeField] private float _moveSpeed;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_isMoving) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            _destination,
            _moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, _destination) < 0.1f)
        {
            _isMoving = false;
        }
    }
   
    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        _isMoving = true;
    }
}
