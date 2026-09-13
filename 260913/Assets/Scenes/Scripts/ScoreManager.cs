using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   private int _score;

   public static ScoreManager Instance { get; private set; }
   
   public int Score => _score;

   private void Awake()
   {
      SetSingleton();
   }

   public void AddScore(int amount)
   {
      _score += amount;
      
      Debug.Log($"ScoreManager: 점수가 {_score}이 되었습니다.");
   }

   private void SetSingleton()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(gameObject);
         return;
      }

      Instance = this;
      DontDestroyOnLoad(gameObject);
   }
}
