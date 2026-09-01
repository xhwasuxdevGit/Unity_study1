using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycleProbe : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("LifeCycleProbe: Awake");
    }

    private void OnEnable()
    {
        Debug.Log("LifeCycleProbe: OnEnable");
    }

    private void Start()
    {
        Debug.Log("LifeCycleProbe: Start");
    }

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

    private void OnDisable()
    {
        Debug.Log("LifeCycleProbe OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("LifeCycleProbe: OnDestroy");
    }
}
