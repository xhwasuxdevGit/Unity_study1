using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackable 
{
    // public BlockType BlockType { get; }  
    public int Count { get; set; }
    public int MaxStack { get; }


}
