using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SignalLight : MonoBehaviour
{
    private Renderer _renderer;
    private readonly WaitForSeconds _waitOneSecond = new WaitForSeconds(1f);
    private Coroutine _signalRoutine;
    private bool _isCrossRequested;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    private void Start()
    {
        
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_signalRoutine == null)
            {
                RoutineStart(); 
            }
            
            else if (_signalRoutine != null)
            {
                StopCoroutine(_signalRoutine);
                _signalRoutine = null;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _isCrossRequested = true;
        }
    }

    private void RoutineStart()
    {
        _signalRoutine = StartCoroutine(RunSignalRoutine());
    }
    
    private IEnumerator RunSignalRoutine()
    {
        while(true)
        {
         _renderer.material.color = Color.red;
         Debug.Log("SignalLight: 빨강으로 변경");
         yield return _waitOneSecond;
         
         _renderer.material.color = Color.yellow;
         Debug.Log("SignalLight: 노랑으로 변경");
         yield return new WaitUntil(() => _isCrossRequested);
         
         _isCrossRequested = false;
         
         _renderer.material.color = Color.green;
         Debug.Log("SignalLight: 초록으로 변경");
         yield return _waitOneSecond;

        }
    }
}
