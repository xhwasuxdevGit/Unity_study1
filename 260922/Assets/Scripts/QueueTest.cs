using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTest : MonoBehaviour
{
    private SimpleQueue<string> _monsters = new SimpleQueue<string>(4);

    private void Start()
    {
        RunOperations();
        RunWrapAround();
        LogFront();
    }

    private void RunOperations()
    {
        _monsters.Enqueue("슬라임");
        _monsters.Enqueue("고블린");
        _monsters.Enqueue("오크");
        LogDequeue();
        _monsters.Enqueue("트롤");
        LogDequeue();
        LogDequeue();
    }

    private void RunWrapAround()
    {
        _monsters.Enqueue("드래곤");
        _monsters.Enqueue("골렘");
        LogDequeue();
        LogDequeue();
    }

    private void LogDequeue()
    {
        Debug.Log($"QueueTest : 꺼낸 값 {_monsters.Dequeue()}");
    }

    private void LogFront()
    {
        Debug.Log($"QueueTest : 남은 개수 {_monsters.Count}, 맨 앞 {_monsters.Peek()}");
    }
}
