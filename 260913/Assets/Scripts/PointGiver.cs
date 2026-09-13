
using System;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    private const int POINT_PER_PRESS = 10;

    private void Start()
    {
        ReportPoint();
    }

    private void Update()
    {
        ReadPointkey();
        Reset();
        
    }

    private void ReportPoint()
    {
        Debug.Log($"PointGiver: 현재 점수는 {PracticeScore.Instance.Point}입니다.");
    }

    private void ReadPointkey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PracticeScore.Instance.AddPoint(10);
        }
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PracticeScore.Instance.ResetPoint(); 
        }
        
    }
}
