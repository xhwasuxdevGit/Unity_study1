using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour
{
    private void Start()
    {
        LogLengths();
        LogDistance();
    }

    private void LogLengths()
    {
        Vector3 right = Vector3.right;
        Vector3 forward = Vector3.forward;
        Vector3 diagonal = right + forward;
        
        Debug.Log($"VectorLength: right의 길이는 {right.magnitude}입니다.");
        Debug.Log($"VectorLength: forward의 길이는 {forward.magnitude}입니다.");
        Debug.Log($"VectorLength: 두 방향을 더한 길이는 {diagonal.magnitude}입니다.");
    }

    private void LogDistance()
    {
        Vector3 myPoint = new Vector3(0f, 0f, 0f);
        Vector3 targetPoint = new Vector3(3f, 0f, 4f);
        Vector3 toTarget = targetPoint - myPoint;
        Debug.Log($"VectorMath: 대상까지의 거리는 {toTarget.magnitude}입니다.");

    }
}
