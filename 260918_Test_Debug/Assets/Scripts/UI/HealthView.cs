using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    
    private TextMeshProUGUI _healthText;
    private void Awake()
    {
        CacheComponents();
    }
    
    private void CacheComponents()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }
    
    // [BUG-03] 원인 : 1)`_healthText` 변수에 값이 배정되어 있지 않음
    //                2)`Show` 함수에서 `_healthText.text`에 값을 입력하는 문법이 잘못됨
    //          수정 : 1) `CacheComponents`를 `Awake`함수에서 호출하여 변수에 해당 UI를 배정함
    //                2) `_healthText.text`에 담을 내용 중 `큰따옴표` 및 `중괄호` 문법을 수정
    public void Show(int health)
    {
        _healthText.text = "HP " + health;
    }
}
