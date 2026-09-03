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

      if (Input.GetKeyDown(KeyCode.D) && clones.Count != 0)
      {
         for (int i = 0; i < clones.Count; i++)
         {
            Destroy(clones[i]);
         }
        
      }
   }

   private void SpawnOne()
   {
      
      Vector3 spawnPosition = new Vector3(_count * 2f, 0f, 0f);
      GameObject clone = Instantiate(_towerPrefab,
         spawnPosition, Quaternion.identity, _spawnRoot);
      clone.name = "망루";
      clone.AddComponent<TowerLifeLog>();
      clones.Add(clone);
      Debug.Log($"TowerSpawner: 방금 없애라고 한 {clone.name}이 아직 여기 있습니다.");
     _count += 1;
      
      
   }
     
   
}
