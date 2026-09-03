using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _boxPrefab;
    [SerializeField] private Transform _boxRoot;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _beltSpeed;
    [SerializeField] private float _lifeSeconds;
    private float _elapsed;
    private int _nextIndex;

    private void Update()
    {
        ReadSpawnKey();
    }

    private void ReadSpawnKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnOne();
        }
    }

    private void SpawnOne()
    {
        if (_nextIndex < _boxPrefab.Length)
        {
            Vector3 spawnPosition = new Vector3(0f, 0.6f, -10);
            Instantiate(_boxPrefab[_nextIndex], 
                spawnPosition, Quaternion.identity, _boxRoot);
            _nextIndex++;
        }
        else
        {
            _nextIndex = 0;
        }

        
        
    }

}
