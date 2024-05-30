using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public event Action OnJumpEvent;

    private LayerMask _groundLayerMask;
    private Rigidbody _rigidbody;
    private float _radius = 0.1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PlayerManager.Instance.Player.Input.OnJumpInputEvent += OnJump;
        _groundLayerMask = LayerMask.GetMask("Ground");
    }

    private void OnJump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * PlayerManager.Instance.Player.Stat.CurrentStat.JumpPower, ForceMode.Impulse);
            OnJumpEvent?.Invoke();
        }
    }

    private bool IsGrounded()
    {
        Vector3 startPos = transform.position + Vector3.up * _radius;
        Vector3 direction = -Vector3.up;

        if (Physics.SphereCast(startPos, _radius, direction, out RaycastHit hit, _radius, _groundLayerMask))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        // 레이의 시작점 설정
        Vector3 startPos = transform.position + Vector3.up * _radius;

        // 레이의 방향 설정 (아래쪽)
        Vector3 direction = -Vector3.up;
        Gizmos.color = Color.yellow;
        // 구체 기즈모를 그림
        Gizmos.DrawWireSphere(startPos + direction * _radius, _radius);
    }
}
