using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointer : MonoBehaviour
{
   private Camera _mainCamera;
   private ISelectable _selectable;
   private GameObject _selected;

   private void Awake()
   {
      _mainCamera = Camera.main;
   }

   private void Update()
   {
      ReadClick();
   }

   private void ReadClick()
   {
      if (Input.GetMouseButtonDown(0))
      {
         PointAtMouse();
      }
   }

   private void PointAtMouse()
   {
      Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
      
      Debug.DrawRay(ray.origin, ray.direction * 20f, Color.yellow, 1f);

      if (Physics.Raycast(ray, out RaycastHit hit))
      {
         
         if (hit.collider.GetComponent<ISelectable>() != null)
         {
            _selectable = hit.collider.GetComponent<ISelectable>();
            Debug.Log($"ClickPointer: {hit.collider.name}을 골랐습니다.");
         }
         
      }
      
   }


}
