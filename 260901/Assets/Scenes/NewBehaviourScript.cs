using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   

    public float JumpForce;
    public Rigidbody _rigidbody;
    
  
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        
        
        
       

    }
}
