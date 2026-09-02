using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStudy : MonoBehaviour
{
   private void Start()
   {
      LogActiveScene();
   }

   private void LogActiveScene()
   {
      Debug.Log($"SceneStudy: 지금 열린 씬은 {SceneManager.GetActiveScene().name}입니다.");
   }
}
