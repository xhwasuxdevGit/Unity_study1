using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Awake 호출");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 호출");
    }

    private void Start()
    {
        Debug.Log("Start 호출");
    }

    private void Update()
    {
        //Debug.Log("Update 호출");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable 호출");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy 호출");
    }
}