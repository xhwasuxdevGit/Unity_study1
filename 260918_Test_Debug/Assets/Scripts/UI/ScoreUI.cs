using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // [BUG-11] 원인 : 게임오버되어 재시작되면 싱글톤으로 설계된 `GameManager`는 유지되는 반면, 
    //                직렬화와 인스펙터 할당을 통해 `AddScore`메서드 에서 연결된
    //                `ScoreText`오브젝트와의 연결 관계 자체는 유지되지 않음
    //          수정 : 1) 씬이 재시작되더라도 참조관계를 유지할 수 있도록, `_scoreText` 필드를 열어두고,
    //                2)`ScoreText`에 스크립트를 추가 자신의 컴포넌트(= `TextMeshProUGUI`)를 가져온 뒤,
    //                3)`GameManager`의 `_scoreText`에 접근해 가져온 컴포넌트를 대입시킴

    private TextMeshProUGUI _scoreUI; 
    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        GameManager.Instance.ScoreText = _scoreUI;
    }

    private void CacheComponents()
    {
        _scoreUI = GetComponent<TextMeshProUGUI>();
    }
    
}
