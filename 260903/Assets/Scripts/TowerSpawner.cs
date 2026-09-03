using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
   [SerializeField] private GameObject _towerPrefab;
   private int _count;
   [SerializeField] private Transform _spawnRoot;
   private List<GameObject> clones = new List<GameObject>();

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
      
      Vector3 spawnPosition = new Vector3(_count * 2f, 0f, 0f);
      for (int i = 0; i < clones.Count; i++)
      { clones.Add(Instantiate(_towerPrefab,
            spawnPosition, Quaternion.identity, _spawnRoot));
         clones[i].name = "망루";
         clones[i].AddComponent<TowerLifeLog>();
         Destroy(clones[i], 2f);
         Debug.Log($"TowerSpawner: 방금 없애라고 한 {clones[i].name}이 아직 여기 있습니다.");
         _count += 1;
         Debug.Log("TowerSpawner: {_count}번째를 만들었고 2초 뒤에 없앱니다.");
      }
     
      
   }
}
