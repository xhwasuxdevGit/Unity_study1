using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStudy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _meterPerSecond = 3f;
    [SerializeField] private float _stopDistance = 0.1f;

    private void Update()
    {
        FaceTarget();
        MoveToTarget();
    }

    private void FaceTarget()
    {
        transform.LookAt(_target);
    }

    private void MoveToTarget()
    {
        Vector3 toTarget = _target.position - transform.position;

        if (toTarget.magnitude < _stopDistance)
        {
            return;
        }

        transform.position += toTarget.normalized * _meterPerSecond * Time.deltaTime;
    }

}
