using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLifeLog : MonoBehaviour
{
   private void Awake()
   {
      ReportBorn();
   }

   private void OnDestroy()
   {
      ReportGone();
   }

   private void ReportBorn()
   {
      Debug.Log("CubeLifeLog: 큐브가 만들어졌습니다.");
   }

   private void ReportGone()
   {
      Debug.Log("CubeLifeLog: 큐브가 사라졌습니다.");
   }
}
