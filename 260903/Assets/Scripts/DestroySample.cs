using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;

    private GameObject _clone;

    private void Start()
    {
        MakeAndDestroy();
    }

    private void Update()
    {
        ReadCloneName();
    }

    private void MakeAndDestroy()
    {
        _clone = Instantiate(_towerPrefab);
        Destroy(_clone);
    }

    private void ReadCloneName()
    {
        Debug.Log($"DestroySample: {_clone.name}");
    }
}
