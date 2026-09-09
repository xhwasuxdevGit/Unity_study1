using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTriggerLogger : MonoBehaviour
{
    private void OntriggerEnter(Collider other)
    {
        Debug.Log($"ShelfTriggerLogger: {other.name}이 들어왔습니다.");
    }
}
