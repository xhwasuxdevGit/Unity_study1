using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private int _score;

    public static GameManager Instance { get; private set; }

    public int Score => _score;

    private void Awake()
    {
        SetSingleton();
    }
    
    // [BUG-11] 원인 : 게임오버되어 재시작되면 싱글톤으로 설계된 `GameManager`는 유지되는 반면, 
    //                직렬화와 인스펙터 할당을 통해 `AddScore`메서드 에서 연결된
    //                `ScoreText`오브젝트와의 연결 관계 자체는 유지되지 않음
    //          수정 : 1) 씬이 재시작되더라도 참조관계를 유지할 수 있도록, `_scoreText` 필드를 열어두고,
    //                2)`ScoreText`에 스크립트를 추가 자신의 컴포넌트(= `TextMeshProUGUI`)를 가져온 뒤,
    //                3)`GameManager`의 `_scoreText`에 접근해 가져온 컴포넌트를 대입시킴
    public void AddScore(int amount)
    {
        _score += amount;
        ScoreText.text = $"SCORE {_score}";
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
