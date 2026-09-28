using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortStudy1 : MonoBehaviour
{
   [SerializeField] private List<int> _numbers = new();

   private void Start()
   {
      for (int i = 0; i < 5 ; i++)
      {
         _numbers.Add(Random.Range(0, 50));
      }
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         BubbleSort();
      }
   }
   

   private void BubbleSort()
   {
      for (int pass = 1; pass < _numbers.Count; pass++)
      {
         for (int point = 0; point < _numbers.Count - pass; point++)
         {
            if (_numbers[point] > _numbers[point + 1])
            {
               Swap(point, point + 1);
            }
         }
      }
      
   }

   /*
    private void BubbleSort2()
   {
      int sortRange = _numbers.Count;

      for (int i = 0; i < _numbers.Count; i++)
      {
         for (int point = 0; point < sortRange; point++)
         {
            if (_numbers[point] > _numbers[point+1])
            {
               Swap(point, point + 1);
            }
         }
         sortRange--;
      }
      
   }
   */

   private void Swap(int first, int second)
   {
      int temp;
      temp = _numbers[first];
      _numbers[first] = _numbers[second];
      _numbers[second] = temp;
   }

   private void PrintNumbers()
   {
      for (int i = 0; i < _numbers.Count; i++)
      {
         Debug.Log($"인덱스 {i}: {_numbers[i]}");
      }
   }
}
