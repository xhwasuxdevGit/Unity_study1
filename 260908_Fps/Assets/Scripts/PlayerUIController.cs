using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _magazine;
   [SerializeField] private PlayerWeapon _weapon;
   
   [SerializeField] private TextMeshProUGUI _grenadeUI;
   [SerializeField] private TextMeshProUGUI _hpUI;
   [SerializeField] private PlayerController _player;
   
   public void RefreshMagazineUI(int currentAmmo)
   {
      _magazine.text = $"{currentAmmo} / {_weapon.MaxAmmo}";
   }

   public void UpdateGrenadeUI(int grenadeCounter)
   {
      _grenadeUI.text = grenadeCounter.ToString();
   }

   public void UPdateHPUI(int playerHP)
   {
      _hpUI.text = playerHP.ToString();
   }
}

