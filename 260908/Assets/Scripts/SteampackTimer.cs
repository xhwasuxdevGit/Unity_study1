using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampackTimer : MonoBehaviour
{
   [SerializeField] private float _duration;
   [SerializeField] private Steampack _steampack;
   
   private float timer;

   private bool _isSteampackEnd
   {
      get { return timer >= _duration; }
   }

   private void Awake()
   {
      CacheComponents();
   }

   private void Update()
   {
      CountTImer();
      DeactivateSteampack();
   }
   
   private void CacheComponents()
   {
      _steampack = _steampack.GetComponentInChildren<Steampack>();
   }
   
   private void CountTImer()
   {
      if (_steampack == null)
      {
         timer += Time.deltaTime;
      }
   }
   
   private void DeactivateSteampack()
   {
      if (_isSteampackEnd)
      {
         _steampack.StopSteampac();
      }
   }

}
