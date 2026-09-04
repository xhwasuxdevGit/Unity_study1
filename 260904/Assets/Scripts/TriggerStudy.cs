using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStudy : MonoBehaviour
{
   private SphereCollider b;
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log($"{gameObject.name} : 트리거 안에 {other.gameObject.name} 들어옴");
      
      if (other.gameObject.CompareTag("Player"))
      {
         Debug.Log("플레이어가 범위 내로 들어왔음. 문열기");
         CubeController c = other.gameObject.GetComponent<CubeController>();
         c.TakeDamage(10);
      }
     
   }
   
   private void OnTriggerEStay(Collider other)
   {
      Debug.Log($"{gameObject.name} : 트리거 안에 {other.gameObject.name} 있음");
   }
   
   private void OnTriggerExit(Collider other)
   {
      Debug.Log($"{gameObject.name} : 트리거에서 {other.gameObject.name} 나감");
   }
}
