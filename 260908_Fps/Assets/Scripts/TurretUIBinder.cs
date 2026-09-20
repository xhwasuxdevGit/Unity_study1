using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUIBinder : MonoBehaviour
{
    [SerializeField] private TurretController _turret;
    [SerializeField] private TurretHPUI _turretHpUI;

    private void OnEnable()
    {
        BindTurretHPUI();
    }

    private void OnDisable()
    {
        UnBindTurretHPUI();
    }
    
    private void BindTurretHPUI()
    {
        _turret.OnHPChanged += _turretHpUI.UpdateUI;
    }

    private void UnBindTurretHPUI()
    {
        _turret.OnHPChanged -= _turretHpUI.UpdateUI;
    }
}
