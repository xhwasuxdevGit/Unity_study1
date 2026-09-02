using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisCompareSample : MonoBehaviour
{
    private const string AXIS_HORIZONTAL = "Horizontal";

    private void Update()
    {
        ReadAxes();
    }

    private void ReadAxes()
    {
        float smoothed = Input.GetAxis(AXIS_HORIZONTAL);
        float raw = Input.GetAxisRaw(AXIS_HORIZONTAL);
        Debug.Log($"AxisCompareSample: GetAxis는 {smoothed}, GetAxisRaw는 {raw}입니다. ");
    }
 
}
