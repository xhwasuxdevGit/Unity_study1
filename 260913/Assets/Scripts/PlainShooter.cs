using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainShooter : MonoBehaviour
{
    [SerializeField] private GameObject _boltPrefab;

    private void Update()
    {
        ReadFireKey();
    }

    private void ReadFireKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_boltPrefab);
        }
    }
}
