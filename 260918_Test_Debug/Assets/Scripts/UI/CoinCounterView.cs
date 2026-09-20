using UnityEngine;
using TMPro;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private TextMeshProUGUI _coinText;
    
    private void OnEnable()
    {
        BindWalletEvents();
    }

    private void Start()
    {
        UpdateText();
    }

    private void BindWalletEvents()
    {
        _wallet.OnCoinCollected += OnCoinCollected;
    }

    // [BUG-07] 원인 : 코인을 `PlayerWallet`에서 카운트 하고있음 에도 불구하고,
    //                `CoinCounterView`에서 추가적으로 더 세고 있음
    //          수정 : `CoinCount`프로퍼티를 참조하여,
    //                `PlayerWallet`에서 센 갯수만 UI에서 출력하도록 변경
    private void OnCoinCollected()
    {
        UpdateText();
    }

    
    private void UpdateText()
    {
        _coinText.text = $"COIN {_wallet.CoinCount}";
    }
}
