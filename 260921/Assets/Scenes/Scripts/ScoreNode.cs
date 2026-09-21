using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNode
{
    public int Value;
    public ScoreNode Next;

    public ScoreNode(int value)
    {
        Value =  value;
    }
}
