using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerStudy : MonoBehaviour
{
  [SerializeField] private float _checkDistance = 10;
  [SerializeField] private LayerMask _target;
    
  private void Update()
  {
    DrawCheckRay();  
    CheckGround();  
  }

  private void DrawCheckRay()
  {
      Debug.DrawRay(transform.position, Vector3.forward * _checkDistance, Color.red);
  }

  private void CheckGround()
  {
      Ray ray = new Ray(transform.position, Vector3.forward);

      if (Physics.Raycast(ray, out RaycastHit hit, _checkDistance, _target))
      {
          Debug.Log($"<color=yellow>LayerStudy: {hit.collider.name} 감지됨.</color>");
      }
  }
  
  
}
