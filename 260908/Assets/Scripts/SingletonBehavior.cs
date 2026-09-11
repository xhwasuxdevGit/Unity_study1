using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
   
   private static T _instance;
   
   public static T Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = FindAnyObjectByType<T>();
            DontDestroyOnLoad(_instance.gameObject);
         }
         return _instance;
      }
   }

   protected void SetSingleton()
   {
      if (_instance != null && Instance != this)
      {
         Destroy(gameObject);
         return;
      }
      else
      {
         _instance = GetComponent<T>();
         DontDestroyOnLoad(gameObject);
      }


   }
}
