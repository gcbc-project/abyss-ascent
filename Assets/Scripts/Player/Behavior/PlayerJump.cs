using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public event Action OnJumpEvent;
    public event Action<bool> OnFallingEvent;
    public event Action<bool> OnGroundedEvent;

    private LayerMask _groundLayerMask;
    private Rigidbody _rigidbody;
    private float _radius = 0.1f;
    private Stamina _stamina;
    private bool _isFalling;
    private bool _isGrounded;

    private void Start()
    {
        _stamina = GetComponent<Stamina>();
        _rigidbody = GetComponent<Rigidbody>();
        _groundLayerMask = LayerMask.GetMask("Ground");
        PlayerManager.Instance.Player.Input.OnJumpInputEvent += OnJump;
    }

    private void Update()
    {
        bool wasFalling = _isFalling;
        bool wasGrounded = _isGrounded;

        _isFalling = !_isGrounded && _rigidbody.velocity.y < -0.5f;
        _isGrounded = IsGrounded();

        if (_isFalling != wasFalling)
        {
            OnFallingEvent?.Invoke(_isFalling);
        }

        if (_isGrounded != wasGrounded)
        {
            OnGroundedEvent?.Invoke(_isGrounded);
        }
    }

    private void OnJump()
    {
        if (!_isFalling && _isGrounded && _stamina.Modify(-PlayerManager.Instance.Player.Stat.CurrentStat.JumpStaminaAmount))
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
