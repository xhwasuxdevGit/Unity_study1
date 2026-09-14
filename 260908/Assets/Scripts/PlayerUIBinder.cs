using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBinder : MonoBehaviour
{
   [SerializeField] private PlayerWeapon _playerWeapon;
   [SerializeField] private PlayerUIController _playerUIController;
   
   private void OnEnable()
   {
      BindPlayerUIChangeEvents();
   }

   private void OnDisable()
   {
      UnBindPlayerUIChangeEvents();
   }
   

   private void BindPlayerUIChangeEvents()
   {
      _playerWeapon.OnAmmoChanged += _playerUIController.RefreshMagazineUI;
   }

   private void UnBindPlayerUIChangeEvents()
   {
      _playerWeapon.OnAmmoChanged -= _playerUIController.RefreshMagazineUI;
   }
}
