
using UnityEngine;

public class LifeCycleProbe : MonoBehaviour
{
    private void Awake() => LogStep("Awake");
  
    private void OnEnable() => LogStep("OnEnable");

    private void Start() => LogStep("Start");
   
    private void FixedUpdate()
    {
        //Debug.Log("LifeCycleProbe: FixedUpdate");
    }

    private void Update()
    {
        //Debug.Log("LifeCycleProbe: Update");
    }

    private void LateUpdate()
    {
        //Debug.Log("LifeCycleProbe: LateUpdate");
    }

    private void OnDisable() => LogStep("OnDisable");
    
    private void OnDestroy() => LogStep("OnDestroy");
    
    private void LogStep(string stepName)
    {
        Debug.Log($"LifeCycleProbe: {stepName}");
    }
}
