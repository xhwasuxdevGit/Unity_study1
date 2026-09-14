using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBinder : MonoBehaviour
{
    private TempPlayer _player;
    [SerializeField] private TempPlayerUI _playerUI;
    [SerializeField] private ExpGauage _expGauage;
    
    private void Awake() => ChacheComponent();

    private void OnEnable() => BindPlayerStatChangeEvents();

    private void OnDisable() => UnBindPlayerStatChangeEvents();
   

    private void BindPlayerStatChangeEvents()
    {
        _player.OnHealthChange += _playerUI.RefreshHealthUI;
        
        _player.Exp.AddListener(_expGauage.RefreshGauage);
    }

    private void UnBindPlayerStatChangeEvents()
    {
        _player.OnHealthChange -= _playerUI.RefreshHealthUI;
        
        _player.Exp.RemoveListener(_expGauage.RefreshGauage);
    }

    private void ChacheComponent()
    {
        _player = GetComponent<TempPlayer>();
    }
}
