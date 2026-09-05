using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CubeController : MonoBehaviour
{
   private Camera _cam;
   [SerializeField] private UnitMovement _target;

   private void Start()
   {
      _cam = Camera.main;
   }
   
   
   private void Update()
   {
      RayShot();
      MoveTarget();
   }

   private void RayShot()
   {
      if (!Input.GetMouseButtonDown(0)) return;
       
      Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit))
      {
         if (hit.transform.CompareTag("Ground"))
         {
            _target = null;
            return;
              
         }
         Debug.Log($"{hit.transform.name} 선택");
         _target = hit.transform.GetComponent<UnitMovement>();
           
      }
      else
      {
         _target = null;
         return;   
      }

   }
   private void MoveTarget()
      {
         if (!Input.GetMouseButtonDown(1) || _target == null) return;
       
         Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit))
         {
            if (!hit.transform.CompareTag("Ground")) return;

            _target.SetDestination(hit.point);
            return;
         }
      }
}
