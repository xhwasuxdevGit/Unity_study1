using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxTrigger : MonoBehaviour
{
   [SerializeField] private AudioSource _source;
   [SerializeField] private AudioClip _hitclip;

   private void Update()
   {
      ReadSoundKeys();
   }

   private void ReadSoundKeys()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _source.PlayOneShot(_hitclip);
         Debug.Log("SfxTrigger: 효과음을 냈습니다.");
      }
      if (Input.GetKeyDown(KeyCode.Return))
      {
         _source.Stop();
         Debug.Log("SfxTrigger: 효과음을 멈췄습니다.");
      }
   }
}
