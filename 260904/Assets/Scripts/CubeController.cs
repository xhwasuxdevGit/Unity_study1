using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CubeController : MonoBehaviour
{
   
   private void Update()
   {
      RayShot();
   }

   private void RayShot()
   {
      Ray ray = new Ray(transform.position, transform.forward);
      
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit))
      {
         Debug.Log(hit.transform.name);

      if (!Input.GetKeyDown(KeyCode.Space)) return;
      
      Ray ray = new Ray(transform.position, transform.forward);

      RaycastHit[] hits = Physics.RaycastAll(ray, 10f);

      if (hits.Length > 0)
      {
         foreach (RaycastHit hit in hits)
         {
            Debug.Log(hit.transform.name);
         }

      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;

      Gizmos.DrawRay(transform.position, transform.forward * 5);

      Gizmos.DrawRay(transform.position, transform.forward*10);

   }
}
