using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteractable
{

    public GameObject GameObject {get => gameObject; }
    private Outline _outline;

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        Init();
    }
    
    public void Targeting()
    {
        _outline.enabled = true;
    }

    public void Untargeting()
    {
        _outline.enabled = false;
    }
    
    public void Interact(IInteractor owner)
    {
        // 상호작용할 거리 - owner의 능력치를 상승
        // 인벤토리로 획득
        // 무기 추가
        // 장탄수 추가

        /*if (!(owner is PlayerController)) return;
        PlayerController player = (PlayerController)owner;*/
        
        // 이동속도 변환 ()
        
        
        Destroy(gameObject);
    }

    private void Init()
    {
        _outline.enabled = false;
    }
    
    private void CacheComponents()
    {
        _outline = gameObject.GetComponent<Outline>();
    }
}
