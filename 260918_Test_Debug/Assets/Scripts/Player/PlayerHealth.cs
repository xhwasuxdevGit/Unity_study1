using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const string TAG_ENEMY = "Enemy";

    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private float _invincibleSeconds = 2f;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private GameFlow _gameFlow;
    
    private readonly WaitForSeconds _waitBlink = new WaitForSeconds(0.1f);
    private Renderer _renderer;
    private int _health;
    private bool _isInvincible;
    
    private Coroutine _blinkRoutine;

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        InitHealth();
    }

    private void Update()
    {
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_ENEMY))
        {
            TakeDamage();
        }
    }

    private void CacheComponents()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void InitHealth()
    {
        _health = _maxHealth;
        _healthView.Show(_health);
    }

    private void TakeDamage()
    {
        if (_isInvincible)
        {
            return;
        }

        _health--;

        if (_health <= 0)
        {
            _gameFlow.ShowGameOver();
        }
        else
        {
            BeginInvincible();
        }

        _healthView.Show(_health);
    }

    private void BeginInvincible()
    {
        _isInvincible = true;
        _blinkRoutine = StartCoroutine(BlinkRoutine());
        StartCoroutine(InvincibleRoutine());
    }

    private IEnumerator InvincibleRoutine()
    {
        yield return new WaitForSeconds(_invincibleSeconds);
        EndBlink();
        _isInvincible = false;
    }

    private void EndBlink()
    {
        StopCoroutine(_blinkRoutine);
        _renderer.enabled = true;
    }
    
    // [BUG-08] 원인 : 적용된 코루틴을 멈추기 위한 키워드 문법이 잘못설정됨
    //                `EndBlink` 메서드에서 실행되고 있는 `BlinkRoutine`을 감지하지 못함
    //          수정 : `_blinkRoutine` 변수에 StartCoroutine(InvincibleRoutine())를 담고,
    //              : `StopCoroutine` 키워드를 통해 실행되고 있는 코루틴을 정지 시킴
    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return _waitBlink;
        }
    }
}
