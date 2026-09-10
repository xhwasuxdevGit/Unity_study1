
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;
    
    private void Start()
    {
        UpdateText();
    }

    public void AddScore()
    {
        _score += 10;
        UpdateText();
    }
    
    private void UpdateText()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
