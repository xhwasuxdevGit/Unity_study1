using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSample : MonoBehaviour
{
    private const string AXIS_MOUSE_X = "Mouse X";
    private const string AXIS_MOUSE_Y = "Mouse Y";

    private void Update()
    {
        ReadMouseDelta();
    }

    private void ReadMouseDelta()
    {
        float mouseX = Input.GetAxis(AXIS_MOUSE_X);
        float mouseY = Input.GetAxis(AXIS_MOUSE_Y);
        Debug.Log($"MouseSample: 마우스가 가로 {mouseX}, 세로 {mouseY}만큼 움직였습니다.");
    }
}
