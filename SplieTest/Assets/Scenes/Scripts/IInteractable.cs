using UnityEngine;
public interface IInteractable 
{
    
    public GameObject GameObject { get; }
    // public BlockType BlockType { get; }
    
    public void Targeted();

    public void Untargeted();

    public void ButtonInteract();

    public void AutoInteract();
}
