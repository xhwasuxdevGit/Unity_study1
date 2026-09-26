using UnityEngine;

public class MoveCommand : ICommand  
{  
    private Transform _target;  
    private Vector3 _step;

    public MoveCommand(Transform target, Vector3 step)  
    {  
        _target = target;  
        _step = step;  
    }

    public void Execute()  
    {  
        _target.position += _step;  
    }

    public void Undo()  
    {  
        _target.position -= _step;  
    }  
}

