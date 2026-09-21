using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Monster[] _monsters;

    private LinkedList<Monster> _turnFlowList = new();
    private LinkedListNode<Monster> _current;

    private void Start()
    {
        foreach (Monster monster in _monsters)
        {
            _turnFlowList.AddLast(monster);
        }

        _current = _turnFlowList.First;
        _current.Value.OnTurnStart();
    }

    private void Update()
    {
        _current.Value.OnTurnRunning();

        if (Input.GetKeyDown(KeyCode.Space) && _current != _turnFlowList.Last)
        {
            _current.Value.OnTurnEnd();
            _current = _current.Next;
            _current.Value.OnTurnStart();
        }
    }




}
