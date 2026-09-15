using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBinder : MonoBehaviour
{
   [SerializeField] private PlayerWeapon _playerWeapon;
   [SerializeField] private PlayerUIController _playerUIController;
   [SerializeField] private GrenadeController _grenade;
   
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
      _grenade.OnGrenadeCountChanged += _playerUIController.UpdateGrenadeUI;
   }

   private void UnBindPlayerUIChangeEvents()
   {
      _playerWeapon.OnAmmoChanged -= _playerUIController.RefreshMagazineUI;
      _grenade.OnGrenadeCountChanged -= _playerUIController.UpdateGrenadeUI;
   }
}
