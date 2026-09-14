using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLog : MonoBehaviour
{
    private void OnEnable()  
    {  
        BindScoreEvents();  
    }

    private void OnDisable()
    {
        UnBindScoreEvents();
    }

    private void BindScoreEvents()  
    {  
        ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void UnBindScoreEvents()
    {
        ScoreManager.Instance.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)  
    {  
        Debug.Log($"ExtraLog: 더 해 보기용 로그입니다");  
    }  
}
