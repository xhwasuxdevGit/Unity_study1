
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
  
  [SerializeField] private float _moveSpeed;
  [SerializeField] private float _rotateSpeed;
 
  
  private void Update()
  {
    Vector3 movement = GetMovement();
    Move(movement);
    //MoveTotarget();
    CubeRotate(movement);
    
    Vector3.Distance()
  }

  private void CubeRotate(Vector3 movement)
  {
    if (movement == Vector3.zero)
    {
      return;
    }
    
    Quaternion look = Quaternion.LookRotation(movement);

    transform.rotation = Quaternion.Slerp(
      transform.rotation,
      look,
      _rotateSpeed * Time.deltaTime
    );

  }
  
  private void Move(Vector3 movement)
  {
    if (movement == Vector3.zero)
    {
      return;
    }

    
   
    transform.Translate(
      Vector3.forward  * _moveSpeed * Time.deltaTime
      );

  }

  private Vector3 GetMovement()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");
    
    Vector3 movement = new Vector3(x, 0, z);
    return movement.normalized;
    // movement.normalized; normalize 대문자와 소문자는 다른 함수! 내용확인하자
  }

  private void MoveTotarget()
  {
    /*
    transform.position = Vector3.Lerp(
      transform.position,
      _target.position,
      _moveSpeed * Time.deltaTime
    );
  
 
    transform.position = Vector3.MoveTowards(
      transform.position, _target.position,
      _moveSpeed * Time.deltaTime
    );
    */
  }

  
  
}
