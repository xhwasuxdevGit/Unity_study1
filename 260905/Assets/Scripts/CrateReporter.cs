using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateReporter : MonoBehaviour
{
    private const string TAG_GROUND = "Ground";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_GROUND))
        {
            Debug.Log($"CreateReporter: 바닥에 닿았습니다.");
        }
        
    }
}
