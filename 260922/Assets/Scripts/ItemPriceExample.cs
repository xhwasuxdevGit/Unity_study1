using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPriceExample : MonoBehaviour
{
    private Dictionary<string, int> _itemPrices = new Dictionary<string, int>();
    
    private void Start()
    {
        AddItems();
        ReadPrice();
        ChangePrices();
        RemoveItems();
        PrintPrices();
    }
    
    private void AddItems()
    {
        _itemPrices.Add("회복 물약", 50);
        _itemPrices.Add("던전 열쇠", 500);
        _itemPrices.Add("낡은 검", 120);
        Debug.Log($"ItemPriceExample: 담긴 아이템 {_itemPrices.Count}개");
    }

    private void ReadPrice()
    {
        int KeyPrice = _itemPrices["던전 열쇠"];
        Debug.Log($"ItemPriceExample: 던전 열쇠 가격 {KeyPrice}골드");
    }

    private void ChangePrices()
    {
        _itemPrices["낡은 검"] = 100;
        _itemPrices["마법 두루마리"] = 300;

        int swordPrice = _itemPrices["낡은 검"];
        Debug.Log($"ItemPriceExample: 낡은 검 가격 {swordPrice}골드");
        Debug.Log($"ItemPriceExample: 담긴 아이템 {_itemPrices.Count}개");
    }

    private void RemoveItems()
    {
        bool isPotionRemoved = _itemPrices.Remove("회복 물약");
        bool isShieldRemoved = _itemPrices.Remove("나무 방패");
        Debug.Log($"ItemPriceExample: 회복 물약 지우기 {isPotionRemoved}, 나무 방패 지우기 {isShieldRemoved}");
        Debug.Log($"ItemPriceExample: 담긴 아이템 {_itemPrices.Count}개");
    }

    private void PrintPrices()
    {
        foreach (KeyValuePair<string, int> pair in _itemPrices)
        {
            Debug.Log($"ItemPriceExample: {pair.Key} {pair.Value}골드");
        }
    }
 
    
    
}
