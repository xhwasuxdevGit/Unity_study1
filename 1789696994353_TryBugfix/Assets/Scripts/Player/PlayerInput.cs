using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string AXIS_HORIZONTAL = "Horizontal";
    private const string AXIS_VERTICAL = "Vertical";

    private PlayerMover _mover;

    private void Awake()
    {
        CacheComponents();
    }

    // [BUG-01] 원인: Update 함수가 소문자 'u'pdate로 적혀 있음
    // [BUG-01] 수정: 대문자 'U'pdate로 변경
    private void Update()
    {
        ReadMoveInput();
    }

    private void CacheComponents()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void ReadMoveInput()
    {
        float horizontal = Input.GetAxisRaw(AXIS_HORIZONTAL);
        float vertical = Input.GetAxisRaw(AXIS_VERTICAL);
        _mover.SetDirection(new Vector3(horizontal, 0f, vertical));
    }
}
