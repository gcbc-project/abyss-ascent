using System;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public event Action<bool> OnClimbEvent;
    public event Action<float> OnClimbingEvent;

    private Rigidbody _rb;
    private LayerMask _groundMask;
    private Vector2 _moveDir;
    private bool _isClimb;
    private float _rayDistance = 0.3f;
    private float _yRayOffset = 0.5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _groundMask = LayerMask.GetMask("Ground");
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += SetMoveDirection;
    }

    private void FixedUpdate()
    {
        CheckForWall();
        if (_moveDir == Vector2.zero) return;
        if (!_isClimb) return;
        OnClimbing();
    }

    private void OnClimbing()
    {
        transform.Translate(Vector3.up * PlayerManager.Instance.Player.Stat.CurrentStat.ClimbSpeed * Time.fixedDeltaTime);
    }

    void CheckForWall()
    {
        if (Physics.Raycast(transform.position, transform.forward, _rayDistance, _groundMask) ||
        Physics.Raycast(transform.position + Vector3.up * _yRayOffset, transform.forward, _rayDistance, _groundMask))
        {
            StartWallClimbing();
        }
        else
        {
            StopWallClimbing();
        }
    }

    void StartWallClimbing()
    {
        if (!_isClimb)
        {
            _isClimb = true;
            OnClimbEvent?.Invoke(_isClimb);
            _rb.useGravity = false;
        }
    }

    void StopWallClimbing()
    {
        if (_isClimb)
        {
            _isClimb = false;
            OnClimbEvent?.Invoke(_isClimb);
            _rb.useGravity = true;
        }
    }

    private void SetMoveDirection(Vector2 vector)
    {
        _moveDir = vector;

        if (_isClimb)
        {
            OnClimbingEvent?.Invoke(_moveDir.magnitude);
        }
    }
}
