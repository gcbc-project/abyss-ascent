using System;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public event Action<bool, int> OnJumpEvent;
    public event Action<bool> OnFallingEvent;
    public event Action<bool> OnGroundedEvent;

    private LayerMask _groundLayerMask;
    private Rigidbody _rigidbody;
    private float _radius = 0.3f;
    private bool _isFalling;
    private bool _isGrounded;
    private int _numberOfJumps;

    private void Start()
    {
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
        if (_isFalling) return;
        if (_numberOfJumps >= PlayerManager.Instance.Player.Stat.CurrentStat.JumpNum) return;

        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        PlayerManager.Instance.Player.IsNotGrounded = true;
        _rigidbody.AddForce(Vector2.up * PlayerManager.Instance.Player.Stat.CurrentStat.JumpPower, ForceMode.Impulse);
        if (!_isGrounded)
        {
            _numberOfJumps++;
        }
        OnJumpEvent?.Invoke(true, _numberOfJumps);
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);
        _numberOfJumps = 0;
        PlayerManager.Instance.Player.IsNotGrounded = false;
        OnJumpEvent?.Invoke(false, _numberOfJumps);
    }

    private bool IsGrounded()
    {
        // Position slightly above the player's feet
        Vector3 startPos = transform.position + Vector3.up * _radius * 1.1f;

        // Direction pointing downwards
        Vector3 direction = -Vector3.up;

        // Use a larger distance to cover the ground distance
        float distance = _radius * 1.2f;

        // Perform the sphere cast
        if (Physics.SphereCast(startPos, _radius, direction, out RaycastHit hit, distance, _groundLayerMask))
        {
            return true;
        }
        return false;
    }
}
