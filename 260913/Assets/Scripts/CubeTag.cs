
using UnityEngine;

public class CubeTag : MonoBehaviour
{
   private static int _tagCount;

   private int _myTag;

   private void Awake()
   {
      TakeTag();
   }

   private void TakeTag()
   {
      if (_tagCount >= PracticeSettings.MaxTagCount)
      {
         Debug.Log("CubeTag: 최대 카운트 횟수에 도달했습니다.");
      }
      else
      {
         _tagCount++;
         _myTag = _tagCount;
         Debug.Log($"CubeTag: 큐브 번호는 {_myTag}이고, 전체 큐브 갯수는 {_tagCount}입니다.");
      }
   }

   public static  void GetTagCount()
   {
      Debug.Log($"CubeTag: 현재까지 생성한 갯수는 {_tagCount}입니다.");
   }

   public static void ResetTagCount()
   {
      _tagCount = 0;
      Debug.Log("CubeTag: 갯수를 센 값을 초기화 했습니다.");
      
   }
}
