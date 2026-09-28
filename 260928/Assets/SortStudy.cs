using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SortStudy : MonoBehaviour
{
   [SerializeField] private List<Enemy> _enemies = new();
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         int compare = 5.CompareTo(7);
         Debug.Log(compare.ToString());
      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _enemies.Sort(EnemyCompare);
         // _enemies.Sort((a, b) => b.Health.CompareTo(a.Health));
      }
   }

   private int EnemyCompare(Enemy a, Enemy b)
   {
      return a.Speed.CompareTo(b.Speed);
   }
}
