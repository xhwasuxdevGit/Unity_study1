using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailItem : MonoBehaviour, IInteractable, IStackable
{
    public GameObject GameObject { get; }
    private int count;

    public int Count
    {
        get { return count; }
        set
        {
            count = value;
        }
    }

    private int maxStack;
    public int MAxStack => maxStack;
    public bool IsFull { get; set; }
    
    public void AutoInteract()
    {
        // 플레이어가 레일 들고 있으면 자동상호작용 호출
    }

    public void ButtonInteract()
    {
        // 플레이어가 레일을 해체할수 있는 상태면 호출
    }

    public void Targeted()
    {
         // 플레이어가 감지 -> 외곽선 표시
    }
    
    public void Untargeted()
    {
        // 플레이어 범위에서 벗어남 -> 외곽선 해제
    } 
    
    
  
  
}
