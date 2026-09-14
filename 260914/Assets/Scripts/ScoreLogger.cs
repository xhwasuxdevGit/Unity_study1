
using UnityEngine;

public class ScoreLogger : MonoBehaviour
{
    private void OnEnable()
    {
        BindScoreEvents();
    }

    private void BindScoreEvents()
    {
        ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        Debug.Log($"ScoreLogger: recorded " + score);
    }
}
