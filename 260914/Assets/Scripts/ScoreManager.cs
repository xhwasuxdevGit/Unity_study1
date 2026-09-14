using System;  
using UnityEngine;

public class ScoreManager : MonoBehaviour  
{  
    private int _score;

    public static ScoreManager Instance { get; private set; }

    public event Action<int> OnScoreChanged;

    private void Awake()  
    {  
        SetSingleton();  
    }

    private void Update()  
    {  
        if (Input.GetKeyDown(KeyCode.Space))  
        {  
            AddScore(10);  
        }  
    }

    public void AddScore(int amount)  
    {  
        _score += amount;

        if (OnScoreChanged != null)
        {
            OnScoreChanged.Invoke(_score);
        }
    }

    private void SetSingleton()  
    {  
        Instance = this;  
    }  
}