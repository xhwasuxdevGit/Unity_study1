using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float _moveSpeed;
  
  [SerializeField] private Transform _cameraPivot;
  [SerializeField] private float _mouseSensitivity;
  [SerializeField] private float _minPitch;
  [SerializeField] private float _maxPitch;

  private float _pitch;
  private Rigidbody _rigidbody;
  public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
  
  
  private void Awake()
  {
    CacheComponents();
  }
  private void CacheComponents()
  {
    _rigidbody = GetComponent<Rigidbody>();
  }
  
  public void Rotate()
  {
      Vector3 input = ReadRotateInput() * _mouseSensitivity;
      
      // 좌우 -> 회전
      transform.Rotate(0, input.y, 0, Space.Self);

      // 상하 -> 범위 내로 들어오게 해야됨
      _pitch = Mathf.Clamp(_pitch + input.x, _minPitch, _maxPitch);
      
      // cameraPivot을 회전시켜야 함
      _cameraPivot.localRotation = Quaternion.Euler(_pitch, 0, 0);
  }

  private Vector3 ReadRotateInput()
  {
    float x = Input.GetAxis("Mouse X");
    float y = Input.GetAxis("Mouse Y");
    
    /*이부분 문제 발생
    return new Vector3(x, y, 0);*/
    // 유저 입력과 월드 좌표상 회전축이 다른문제 해결
    // 상하 시점이 반대로 움직이는 문제 해결
    //return new Vector3(y, x, 0);
    return new Vector3(-y, x, 0);
  }
  

  private Vector3 ReadMoveInput()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");
    
    return new Vector3(x, 0, z).normalized;
  }

  public void Move()
  {
    Vector3 input = ReadMoveInput();
    
    // 새로운 velocity 값 설정
    Vector3 direction = transform.right * input.x +
                        transform.forward * input.z;
    
    Vector3 newVelocity = new Vector3(
      direction.x * MoveSpeed, 
      _rigidbody.velocity.y,
      direction.z * MoveSpeed
      );
    
    // 절대좌표로 시점 회전의 문제 발생
    // Vector3 newVelocity = new Vector3(input.x * _moveSpeed, _rigidbody.velocity.y, input.z * _moveSpeed);

    // _rigidbody.velocity에 적용
    _rigidbody.velocity = newVelocity;
  }

 
}
