
using UnityEngine;

public class ScoreLogger : MonoBehaviour
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
       ScoreManager.Instance.OnScoreChanged.AddListener(OnScoreChanged);
    }
    
    private void UnBindScoreEvents()
    {
        ScoreManager.Instance.OnScoreChanged.RemoveListener(OnScoreChanged);
    }

    public void OnScoreChanged(int score)
    {
        Debug.Log($"ScoreLogger: recorded {score}");
    }
}
