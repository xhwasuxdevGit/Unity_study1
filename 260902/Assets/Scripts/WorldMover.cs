using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    [SerializeField] private float _degreePerSecond = 90f;
    [SerializeField] private float _meterPerSecond = 3f;
    
    private void Update()
    {
        //SpinSelf();
        MoveByWorld();
    }

    private void SpinSelf()
    {
        transform.Rotate(Vector3.up * _degreePerSecond * Time.deltaTime);
        
    }

    private void MoveByWorld()
    {
        transform.Translate(Vector3.forward 
                            * _meterPerSecond 
                            * Time.deltaTime, 
            Space.Self);
    }
}
