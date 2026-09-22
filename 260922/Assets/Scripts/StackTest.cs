using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTest : MonoBehaviour
{
    private SimpleStack<string> _monsters = new SimpleStack<string>(4);

    private void Start()
    {
        RunOperations();
        LogTop();
    }

    private void RunOperations()
    {
        _monsters.Push("슬라임");
        _monsters.Push("고블린");
        _monsters.Push("오크");
        LogPop();
        _monsters.Push("트롤");
        LogPop();
        LogPop();
    }

    private void LogPop()
    {
        Debug.Log($"StackTest : 꺼낸 값 {_monsters.Pop()}");
    }

    private void LogTop()
    {
        Debug.Log($"StackTest : 남은 갯수 {_monsters.Count}, 맨 위 {_monsters.Peek()}");
    }
}
