using UnityEngine;

public class Bullet : MonoBehaviour  
{  
    [SerializeField] private float _meterPerSecond = 8f;  
    [SerializeField] private float _lifeSeconds = 2f;

    private float _elapsed;

    private void Update()  
    {  
        MoveForward();  
        CountLifeTime();  
    }

    public void ResetState(Vector3 startPosition)  
    {  
        transform.position = startPosition;  
        _elapsed = 0f;  
    }

    private void MoveForward()  
    {  
        transform.Translate(Vector3.forward * _meterPerSecond * Time.deltaTime);  
    }

    private void CountLifeTime()  
    {  
        _elapsed += Time.deltaTime;

        if (_elapsed >= _lifeSeconds)  
        {  
            BulletPool.Instance.Return(gameObject);  
        }  
    }  
}

