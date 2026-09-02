using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProbe : MonoBehaviour
{
    private const string AXIS_HORIZONTAL = "Horizontal";
    [SerializeField] private float _amountPerSecond = 3f;
    private const int MOUSE_BUTTON_LEFT = 0;

    private float _total;
    
    private Renderer _renderer;
    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        //ReadToggleKey();
        //ReadAxes();
        ReadMouseButton();
    }
    
    private void CacheComponents()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void ReadToggleKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _renderer.enabled = !_renderer.enabled;
            Debug.Log($"InputProbe: 물체의 표시 상태는 {_renderer.enabled}입니다.");
        }
    }

    private void ReadAxes()
    {
        
        float raw = Input.GetAxisRaw(AXIS_HORIZONTAL);
        _total += raw * _amountPerSecond * Time.deltaTime;
        Debug.Log($"InputProbe: 누적값은 {_total}입니다.");
    }

    private void ReadMouseButton()
    {
        if (Input.GetMouseButton(MOUSE_BUTTON_LEFT))
        {
            Debug.Log($"InputProbe: 마우스가 클릭한 좌표는 {Input.mousePosition}입니다.");
        }
    }
   
}
