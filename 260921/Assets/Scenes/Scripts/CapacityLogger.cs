using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityLogger : MonoBehaviour
{
    private List<string> _names = new List<string>(8);

    private void Start()
    {
        LogSize("만든 직후");
        FillNames();
        TrimNames();
        ClearNames();
    }

    private void FillNames()
    {
        for (int i = 1; i <= 5; i ++)
        {
            _names.Add($"슬라임 {i}");
        }

        LogSize("다섯 개를 넣은 뒤");
    }

    private void TrimNames()
    {
        _names.TrimExcess();
        LogSize("TrimExcess 뒤");
    }

    private void ClearNames()
    {
        _names.Clear();
        LogSize("Clear 뒤");
    }

    private void LogSize(string moment)
    {
        Debug.Log($"CapacityLogger : {moment} Count {_names.Count}, Capacity {_names.Capacity}");
    }
}
