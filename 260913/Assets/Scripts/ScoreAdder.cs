using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    private const int SCORE_PER_HIT = 10;

    private void Start()
    {
        ReportCurrentScore();
    }

    private void Update()
    {
        ReadScoreKey();
    }

    private void ReportCurrentScore()
    {
        Debug.Log($"ScoreAdder: 지금 점수는 {ScoreManager.Instance.Score}입니다.");
    }

    private void ReadScoreKey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScoreManager.Instance.AddScore(SCORE_PER_HIT);
        }
    }
}
