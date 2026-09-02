using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySwitcher : MonoBehaviour
{
   private const string SCENE_TITLE = "TITLE";

   private void Update()
   {
      ReadSceneKeys();
   }

   private void ReadSceneKeys()
   {
      if (Input.GetKeyDown(KeyCode.Return))
      {
         Debug.Log($"PlaySwitcher: {SCENE_TITLE} 씬을 부릅니다.");
         SceneManager.LoadScene(SCENE_TITLE);
      }
   }
}
