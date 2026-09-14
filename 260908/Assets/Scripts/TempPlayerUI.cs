using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempPlayerUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _playerHealthText;
   
   public void RefreshHealthUI(int health)
   {
      Debug.Log("UI 갱신");
      _playerHealthText.text = health.ToString();
   }
}  
