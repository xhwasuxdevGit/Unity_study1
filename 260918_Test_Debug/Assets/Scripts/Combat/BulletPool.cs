using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _pool;
    private Rigidbody _body;
   

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
        CreatePool();
    }

    public GameObject Take()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].activeSelf)
            {
                continue;
            }
            
            _pool[i].SetActive(true);
            
            return _pool[i];
        }

        return null;
    }

    // [BUG-10] 원인 : 총알이 비활성활됨에도 불구하고, 총알의 물리연산은 계속 유지되고 있음
    //                따라서 풀에서 다시 꺼내져 활성화되면, 물리연산값을 유지한채로 소환됨
    //          수정 : 총알이 오브젝트풀로 다시 들어갈때, 적용되고 있는 물리연산값을 초기화 시켜줌      
    public void Return(GameObject bullet)
    {
        _body =  bullet.GetComponent<Rigidbody>();
        _body.velocity = Vector3.zero;
        _body.angularVelocity = Vector3.zero; // 회전 운동도 같이 초기화 시켜줘야 함
        bullet.SetActive(false);
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

    private void CreatePool()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform);
            bullet.SetActive(false);
            _pool.Add(bullet);
        }
    }
}
