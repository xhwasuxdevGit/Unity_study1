
using UnityEngine;

public class LifeCycleProbe : MonoBehaviour
{
    private float _elapsed1;
    private float _elapsed2;
    
    private void Awake() => LogStep("Awake");
  
    private void OnEnable() => LogStep("OnEnable");

    private void Start() => LogStep("Start");
   
    private void FixedUpdate()
    {
        Debug.Log("LifeCycleProbe: FixedUpdate");
        _elapsed1 += Time.deltaTime;
        Debug.Log(_elapsed1);
    }

    private void Update()
    {
        Debug.Log("LifeCycleProbe: Update");
        
        _elapsed2 += Time.deltaTime;
        Debug.Log(_elapsed2);
    }

    private void LateUpdate()
    {
        Debug.Log("LifeCycleProbe: LateUpdate");
    }

    private void OnDisable() => LogStep("OnDisable");
    
    private void OnDestroy() => LogStep("OnDestroy");
    
    private void LogStep(string stepName)
    {
        Debug.Log($"LifeCycleProbe: {stepName}");
    }
}
