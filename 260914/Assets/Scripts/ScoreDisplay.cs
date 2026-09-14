using UnityEngine;

public class ScoreDisplay : MonoBehaviour  
{  
   private void OnEnable()  
   {  
      BindScoreEvents();  
   }

   private void OnDisable()
   {
      UnBindScoreEvents();
   }

   private void BindScoreEvents()  
   {  
      ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
     
   }

   private void UnBindScoreEvents()
   {
      ScoreManager.Instance.OnScoreChanged -= OnScoreChanged;
   }

   private void OnScoreChanged(int score)  
   {  
      Debug.Log($"ScoreDisplay: score is {score}");  
   }  
}

