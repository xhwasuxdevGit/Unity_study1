using System.Collections.Generic;
using UnityEngine;

public class LinkedListStudy : MonoBehaviour
{

    private LinkedList<int> _scores = new LinkedList<int>();

    private void Start()
    {
       FillScores();
       InsertAfterScore(75, 80);
       LogScores();
       RemoveLastScore();
       LogScoresBackWard();
    }

    private void FillScores()
    {
        _scores.AddLast(90);
        _scores.AddLast(75);
        _scores.AddLast(88);
       
    }

    private void InsertAfterScore(int target, int value)
    {
        LinkedListNode<int> node = _scores.Find(target);

        if (node != null) 
        {
            _scores.AddAfter(node, value);
        }
        
    }

    private void RemoveLastScore()
    {
        
        if (_scores.Last != null)
        {
            _scores.Remove(_scores.Last);    
        }
    }

    private void LogScores()
    {
        LinkedListNode<int> current = _scores.First;

        while (current != null)
        {
            Debug.Log($"LinkedListStudy: 앞에서부터 {current.Value}");
            current = current.Next;
        }
    }

    private void LogScoresBackWard()
    {
        LinkedListNode<int> current = _scores.Last;

        while (current != null)
        {
            Debug.Log($"LinkedListStudy: 뒤에서부터 {current.Value}");
            current = current.Previous;
        }
    }

    private int GetScoreAt(int index)
    {
        LinkedListNode<int> current = _scores.First;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }
    
}
