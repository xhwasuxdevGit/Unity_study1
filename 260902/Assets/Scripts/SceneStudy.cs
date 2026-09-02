using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStudy : MonoBehaviour
{
   private const string SCENE_PLAY = "Play";

   private void Update()
   {
      ReadSceneKeys();
   }
   
   private void  ReadSceneKeys()
   {
      if (Input.GetKeyDown(KeyCode.Return))
      {
         Debug.Log($"SceneStudy: {SCENE_PLAY} 씬을 부릅니다.");
         SceneManager.LoadScene(SCENE_PLAY);
      }
   }
}
