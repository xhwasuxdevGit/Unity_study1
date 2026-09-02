using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStudy : MonoBehaviour
{
   [SerializeField] private int _score = 10;
   
   private void Awake()
   {
      KeepAlive();
   }

   private void KeepAlive()
   {
      DontDestroyOnLoad(gameObject);
      Debug.Log($"SceneStudy: 씬이 바뀌어도 유지됩니다. 들고 있는 값은 {_score}입니다.");
   }
}
