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
        CountTime();
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
            GameObject _box = Instantiate(_boxPrefab[_nextIndex], 
                spawnPosition, Quaternion.identity, _boxRoot);
            _nextIndex++;

            _box.AddComponent<BeltMover>()._speedPerSecond = _beltSpeed;
            
            
            Destroy(_box, _lifeSeconds);
        }
        else
        {
            _nextIndex = 0;
        }
    }

    private void CountTime()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed >= _spawnInterval)
        {
            SpawnOne();
            _elapsed = 0;
        }
    }

}
