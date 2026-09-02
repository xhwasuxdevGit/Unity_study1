
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
  
  [SerializeField] private float _moveSpeed;
  [SerializeField] private Transform _target;
  
  private void Update()
  {
    //Move();
    MoveTotarget();
  }

  private void MoveTotarget()
  {
    
    
    
    /*
    transform.position = Vector3.MoveTowards(
      transform.position, _target.position,
      _moveSpeed * Time.deltaTime
    );
    */
  }

  private void Mover()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");
    
    Vector3 movement = new Vector3(x, 0, z);
    movement.Normalize();
    // movement.normalized; normalize 대문자와 소문자는 다른 함수! 내용확인하자

    //transform.position += movement * _moveSpeed * Time.deltaTime;
    transform.Translate(movement * _moveSpeed * Time.deltaTime);


  }
  
  
}
