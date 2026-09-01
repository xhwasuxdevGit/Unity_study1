using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    [Header("회전 관련 데이터")]
    [Tooltip("회전 관련 데이터를 설정합니다")]
    [SerializeField] [Range(0, 300)] private float _rotSpeed;

    public float JumpForce;
    public Rigidbody _rigidbody;
    
    [field:SerializeField]public float MoveSpeed { get; private set; }
    public Vector3 _tempVector;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        
        
        
        transform.Rotate(Vector3.up * _rotSpeed * Time.deltaTime);

    }
}
