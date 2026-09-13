using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltShooter : MonoBehaviour
{
    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject _bolt = BoltPool.Instance.Take();
        
        if(_bolt == null) return;
        
        _bolt.GetComponent<Bolt>().ResetState(transform.position);
    }

   
}
