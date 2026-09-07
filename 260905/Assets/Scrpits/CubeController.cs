using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour, ISelectable
{
  private Camera _cam;
  [SerializeField] private float _detectRange;
  
  
  
  private void Start()
  {
    _cam = Camera.main;
  }

  private void Update()
  {
    DetectMOnster();
  }
  

  private void DetectMOnster()
  {
    if (!Input.GetKeyDown(KeyCode.Alpha1)) return;
    
      Collider[] cols = Physics.OverlapSphere(transform.position, _detectRange);

      foreach (Collider col in cols)
      {
        if (col.gameObject.CompareTag("Monster"))
        {
          Debug.Log(col.gameObject.name);
        }
      }
  }
  
}


