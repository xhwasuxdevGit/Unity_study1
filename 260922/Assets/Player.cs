using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TestRoutine());
    }

    private IEnumerator TestRoutine()
    {
        while (true)
        {
            yield return CoroutineExtensions.GetWaitSeconds(0.5f);
            Debug.Log("플레이어 코루틴 실험중");
        }
    }
}
