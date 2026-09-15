using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour, IInteractable
{
    public GameObject GameObject
    {
        get => gameObject;
    }

    private Outline _outline;

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        Init();
    }

    private void CacheComponents()
    {
        _outline = GetComponent<Outline>();
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
        Destroy(gameObject);
    }

    private void Init()
    {
        _outline.enabled = false;
    }
}
  
