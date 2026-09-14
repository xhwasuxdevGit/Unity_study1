using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _magazine;
   [SerializeField] private PlayerWeapon _weapon;
   
   public void RefreshMagazineUI(int currentAmmo)
   {
      _magazine.text = $"{currentAmmo} / {_weapon.MaxAmmo}";
   }
}

