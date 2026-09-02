using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibiilityToggle : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        ReadToggleKey();
    }

    private void CacheComponents()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void ReadToggleKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleVisual();
        }
    }

    private void ToggleVisual()
    {
        _renderer.enabled = !_renderer.enabled;
        Debug.Log($"VisibiilityToggle: 보이기 상태는 {_renderer.enabled}입니다.");
    }
}
