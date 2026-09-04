using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelector : MonoBehaviour, ISelectable
{
    private Camera _cam;
    private ISelectable _target;
    
    public void Select()
    {
        if (!Input.GetMouseButtonDown(0)) return;
       
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
         
            Debug.Log($"{hit.transform.name} 선택");
            _target = hit.transform.GetComponent<ISelectable>();
           
        }
        else
        {
            _target = null;
            return;   
        }
    }
}
