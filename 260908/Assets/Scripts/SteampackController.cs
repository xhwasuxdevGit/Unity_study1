using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampackController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _steampack;
    [SerializeField] private float _duration;
    
    private PlayerMovement _playerMovement;
    private PlayerWeapon _playerWeapon;
    
    private float _defaultSpeed;
    private float _defaultCooldown;
    private bool _isBuffOn;
    private bool _nullStopper;
    private Coroutine _steampackRoutine;
    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        UseSteampack();
    }

    private void CacheComponents()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
      
        _playerWeapon = _player.GetComponentInChildren<PlayerWeapon>();
    }

    private void Init()
    {
        _defaultSpeed = _playerMovement.MoveSpeed;
        _defaultCooldown = _playerWeapon.AttackCooldown;
        _isBuffOn = false;
    }

    private void UseSteampack()
    {
        if(_nullStopper || _isBuffOn) return;

        if (_steampack == null)
        {
            _steampackRoutine = StartCoroutine(SteampackRoutine());
            _nullStopper = true;
        }
    }
    
    public IEnumerator SteampackRoutine()
    {
        _isBuffOn = true;
        ActivateSteampac();
        yield return new WaitForSeconds(_duration);
        DeactivateSteampac();
    } 
   
    private void ActivateSteampac()
    {
        _player.CurrentHp -= 10;
        _playerMovement.MoveSpeed += 10f;
        _playerWeapon.AttackCooldown -= 0.2f;
        Debug.Log($"Steampack: 스팀팩 적용, 현재 체력: {_player.CurrentHp}");
        _isBuffOn = false;
    }

    private void DeactivateSteampac()
    {
        _playerMovement.MoveSpeed = _defaultSpeed;
        _playerWeapon.AttackCooldown = _defaultCooldown;
        Debug.Log("Steampack: 스팀팩 효과 끝!");
    }
    
    
}
