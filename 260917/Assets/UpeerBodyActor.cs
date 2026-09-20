using UnityEngine;

public class UpperBodyActor : MonoBehaviour  
{  
    private const string LAYER_UPPER_BODY = "UpperBody";  
    private const string PARAM_DO_UPPER_ACTION = "DoUpperAction";  
    private const float WEIGHT_ON = 1f;  
    private const float WEIGHT_OFF = 0f;

    private readonly int _doUpperActionId = Animator.StringToHash(PARAM_DO_UPPER_ACTION);

    private Animator _animator;  
    private int _upperBodyLayerIndex;  
    private bool _isUpperBodyRaised;

    private void Awake()  
    {  
        CacheAnimator();  
        CacheLayerIndex();  
    }

    private void Update()  
    {  
        ReadInput();  
    }

    private void CacheAnimator()  
    {  
        _animator = GetComponentInChildren<Animator>();  
    }

    private void CacheLayerIndex()  
    {  
        _upperBodyLayerIndex = _animator.GetLayerIndex(LAYER_UPPER_BODY);  
    }

    private void ReadInput()  
    {  
        if (Input.GetKeyDown(KeyCode.E))  
        {  
            ToggleUpperBody();  
        }  
    }

    private void ToggleUpperBody()  
    {  
        if (_isUpperBodyRaised)  
        {  
            LowerUpperBody();  
        }  
        else  
        {  
            RaiseUpperBody();  
        }  
    }

    private void RaiseUpperBody()  
    {  
        _animator.SetLayerWeight(_upperBodyLayerIndex, WEIGHT_ON);  
        _animator.SetTrigger(_doUpperActionId);  
        _isUpperBodyRaised = true;  
        Debug.Log("UpperBodyActor: 상체 레이어를 올리고 상체 동작을 알립니다");  
    }

    private void LowerUpperBody()  
    {  
        _animator.SetLayerWeight(_upperBodyLayerIndex, WEIGHT_OFF);  
        _isUpperBodyRaised = false;  
        Debug.Log("UpperBodyActor: 상체 레이어를 내립니다");  
    }  
}