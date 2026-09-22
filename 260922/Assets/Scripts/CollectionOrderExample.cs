using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOrderExample : MonoBehaviour
{
    private Stack<string> _monsterStack = new Stack<string>();
    private Queue<string> _monsterQueue = new Queue<string>();

    private void Start()
    {
        RunStackOperations();
        RunQueueOperations();
     
    }

    private void RunStackOperations()
    {
        _monsterStack.Push("슬라임");
        _monsterStack.Push("고블린");
        _monsterStack.Push("오크");
        Debug.Log($"CollectionOrderExample : 스택에서 꺼낸 값 {_monsterStack.Pop()}");
        _monsterStack.Push("트롤");
        Debug.Log($"CollectionOrderExample : 스탹에서 꺼낸 값 {_monsterStack.Pop()}");
        Debug.Log($"CollectionOrderExample : 스탹에서 꺼낸 값 {_monsterStack.Pop()}");
        Debug.Log($"CollectionOrderExample : 스택 맨 위 {_monsterStack.Peek()}");
    }

    private void RunQueueOperations()
    {
        _monsterQueue.Enqueue("슬라임");
        _monsterQueue.Enqueue("고블린");
        _monsterQueue.Enqueue("오크");
        Debug.Log($"CollectionOrderExample : 큐에서 꺼낸 값 {_monsterQueue.Dequeue()}");
        // 슬라임
        _monsterQueue.Enqueue("트롤");
        Debug.Log($"CollectionOrderExample : 큐에서 꺼낸 값 {_monsterQueue.Dequeue()}");
        // 고블린
        Debug.Log($"CollectionOrderExample : 큐에서 꺼낸 값 {_monsterQueue.Dequeue()}");
        // 오크
        Debug.Log($"CollectionOrderExample : 큐 맨 앞 {_monsterQueue.Peek()}");
    }
}
