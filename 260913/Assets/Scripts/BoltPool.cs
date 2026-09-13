using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
   [SerializeField] private GameObject boltPrefab;
   [SerializeField] private int _poolSize = 8;
   
   private GameObject[] _bolts;
   private int _count;

   public static BoltPool Instance {get; private set; }

   private void Awake()
   {
      SetSingleton();
   }

   private void Start()
   {
      FillPool();
   }

   private void SetSingleton()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(gameObject);
         return;
      }

      Instance = this;
   }

   private void FillPool()
   {
      _bolts = new GameObject[_poolSize];
      for (int i = 0; i < _poolSize; i++)
      {
         GameObject _bolt = Instantiate(boltPrefab);
         _bolt.SetActive(false);

         _bolts[i] = _bolt;
      }

      _count = _poolSize;
   }

   public GameObject Take()
   {
      if (_count > 0)
      {
         _count--;
         GameObject _bolt = _bolts[_count];
         _bolt.SetActive(true);
         return _bolt;
      }
      
         Debug.Log("남은 총알이 없어 나타낼 수 없습니다.");
         return null;
   }

   public void Return(GameObject _bolt)
   {
      _bolt.SetActive(false);
      _bolts[_count] = _bolt;
      _count++;
   }
}
