using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCounter : MonoBehaviour
{
   private float _elapsed;

   private void Awake()
   {
      KeepAlive();
   }

   private void Update()
   {
      Accmulate();
      ReadLogKey();
   }

   private void KeepAlive()
   {
      DontDestroyOnLoad(gameObject);
      Debug.Log("RunCounter: 유지 대상으로 등록했습니다.");
   }

   private void Accmulate()
   {
      _elapsed += Time.deltaTime;
   }

   private void ReadLogKey()
   {
      if (Input.GetKeyDown(KeyCode.C))
      {
         Debug.Log($"RunCounter: 흐른 시간은 {_elapsed}초 입니다.");
      }
   }
}
