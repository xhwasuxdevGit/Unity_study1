using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour, ISelectable
{
    private Camera _mainCamera;
    private Vector3 _targetPosition;
    private Transform _selected;
    private Rigidbody _rigidbody;
    private bool _isMoving;
    [SerializeField] float _moveSpeed = 5f;
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        GetInput();
        Move();
    }
    

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _selected = hit.transform;
            }
        }
        
    }

    private void Move()
    {
        if (_selected == null) return;
        
        float distance = Vector3.Distance(_selected.position, _targetPosition);

        if (Input.GetMouseButton(1))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                _targetPosition = hit.point;
            }
            
            if (distance > 0.05f)
            {
                _selected.position = Vector3.MoveTowards(
                    _selected.position, _targetPosition, _moveSpeed * Time.deltaTime);
            }
        }
        
        
        
    }
    
    
    
}
