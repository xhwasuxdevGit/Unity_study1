using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMover : MonoBehaviour
{
    [field: SerializeField] public float _speedPerSecond { get; set; }

    private void Update()
    {
        MoveBox();
    }

    private void MoveBox()
    {
        transform.Translate(Vector3.forward * _speedPerSecond * Time.deltaTime);
        
    }
}
