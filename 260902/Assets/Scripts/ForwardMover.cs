using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{

    [SerializeField] private float _meterPerSecond = 3f;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 direction = Vector3.forward;
        transform.position += direction * _meterPerSecond * Time.deltaTime;
    }
}
