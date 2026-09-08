using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steampack : MonoBehaviour, IInteractable
{
   
   [SerializeField] private PlayerController _player;
   [SerializeField] private float _maxDuration;
   private PlayerMovement _playerMovement;
   private PlayerWeapon _playerWeapon;

   private float _defaultSpeed;
   private float _defaultCooldown;
   public GameObject GameObject {get => gameObject; }
   private Outline _outline;
   
   
   private void Awake()
   {
      CacheComponents();
   }

   private void Start()
   {
      Init();
   }

   private void CacheComponents()
   {
      _playerMovement = _player.GetComponent<PlayerMovement>();
      _defaultSpeed = _playerMovement.MoveSpeed;
      _playerWeapon = _player.GetComponentInChildren<PlayerWeapon>();
      _defaultCooldown = _playerWeapon.AttackCooldown;
      _outline = gameObject.GetComponent<Outline>();
   }

   private void Init()
   {
      _outline.enabled = false;
      
   }

   public void Interact(IInteractor owner)
   {
      
      ActivateSteampac();
      Destroy(gameObject);

   }

   public void ActivateSteampac()
   {
      _player.CurrentHp -= 10;
      _playerMovement.MoveSpeed += 10f;
      _playerWeapon.AttackCooldown -= 0.2f;
      Debug.Log($"SteampackController: 스팀팩 적용, 현재 체력: {_player.CurrentHp}");
   }

   public void StopSteampac()
   {
      _playerMovement.MoveSpeed = _defaultSpeed;
      _playerWeapon.AttackCooldown = _defaultCooldown;

   }
   
   public void Targeting()
   {
      _outline.enabled = true;
   }
   
   public void Untargeting()
   {
      _outline.enabled = false;
   }
   
   
}
