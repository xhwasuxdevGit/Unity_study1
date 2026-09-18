using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    public static GameManager Instance { get; private set; }

    public int Score => _score;

    private void Awake()
    {
        SetSingleton();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _scoreText.text = $"SCORE {_score}";
    }

    public void ResetScore()
    {
        _score = 0;
    }

    // [BUG-06] 원인 : 싱글톤 설정 오류 - `GameManager`가 싱글톤으로 설정되지 않아 계속 오디오 컴포넌트 역시 계속 생성됨
    //                싱글톤 함수 내부 - `Instance`를 자신만 유지시키는 조건과 이를 벗어난 객체를 제거하는 로직 부재
    //          수정 : `Instance`가 자신이 아닌 객체로 채워져있으면, 이를 제거하는 조건문 추가하여 자신만 존재하도록 함
    
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
}
