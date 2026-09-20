using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string TAG_WALL = "Wall";

    [SerializeField] private float _meterPerSecond = 5f;

    private Rigidbody _body;
    private Vector3 _direction;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        MoveByTransform();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_WALL))
        {
            Debug.Log("PlayerMover: 벽에 닿았습니다.");
        }
    }

    public void SetDirection(Vector3 direction)
    {
        // [Bug-02] 원인: 키 입력을 받아 방향을 지정하는 Vector3의 값이 `단위 벡터(방향)`가 아닌 `움직일 거리`로 반영됨
        // [Bug-02] 수정: 키를 입력받아 지정되는 `direction`을 `normalized` 키워드를 사용해 "길이를 1로 고정"하여 방향만 지정하게 함
        _direction = (direction).normalized;
    }

    private void CacheComponents()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void MoveByTransform()
    {
        transform.position += _direction * _meterPerSecond * Time.deltaTime;
    }
}
