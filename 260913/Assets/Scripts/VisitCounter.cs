using UnityEngine;
using UnityEngine.SceneManagement;

public class VisitCounter : MonoBehaviour
{
   private const string SCENE_ONE = "StageOne";
   private const string SCENE_TWO = "StageTwo";

   private static int _visitCount;

   private void Start()
   {
      ReportVisit();
   }

   private void Update()
   {
      ReadSceneKey();
   }

   private void ReportVisit()
   {
      _visitCount++;
      
      Debug.Log($"VisitCounter: 신을 연 것은 통틀어 {_visitCount}번째입니다.");
   }

   private void ReadSceneKey()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         MoveToOtherScene();
      }
   }

   private void MoveToOtherScene()
   {
      string currentName = SceneManager.GetActiveScene().name;
      string nextName = currentName == SCENE_ONE ? SCENE_TWO : SCENE_ONE;
      
      SceneManager.LoadScene(nextName);
   }


}
