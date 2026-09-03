using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    [SerializeField] private string _boxName = "기본 상자";

    private void Start()
    {
        OnBoxLog();
    }

    private void OnBoxLog()
    {
        Debug.Log($"BoxInfo: {_boxName}가 벨트에 올라왔습니다.");
    }

    private void OnDestroy()
    {
        OffBoxLog();
    }
    
    private void OffBoxLog()
    {
        Debug.Log($"BoxInfo: {_boxName}가 벨트에서 내려왔습니다.");
    }
}
