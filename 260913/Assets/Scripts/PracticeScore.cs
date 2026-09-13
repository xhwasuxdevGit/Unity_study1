
using UnityEngine;

public class PracticeScore : MonoBehaviour
{
    private int _point;
    
    public static PracticeScore Instance { get; private set; }

    public int Point => _point;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoint(int amount)
    {
        _point += amount;
        Debug.Log($"PracticeScore: 점수가 {_point}이 되었습니다.");
    }

    public void ResetPoint()
    {
        _point = 0;
        Debug.Log("포인트가 초기화되었습니다.");
    }
}
