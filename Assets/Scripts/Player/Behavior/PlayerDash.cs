using System;
using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public event Action<bool> OnDashEvent;
    private bool _isDashing = false;
    private Vector2 _moveDirection;
    private Stamina _stamina;

    private void Start()
    {
        _stamina = GetComponent<Stamina>();
        PlayerManager.Instance.Player.Input.OnDashInputEvent += OnDash;
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += SetMoveDirection;
    }

    private void OnDash()
    {
        if (_isDashing) return;
        if (!_stamina.Modify(-PlayerManager.Instance.Player.Stat.CurrentStat.DashStaminaAmount)) return;

        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        _isDashing = true;
        OnDashEvent?.Invoke(_isDashing);

        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        Vector3 dashDirection = transform.forward;
        if (CameraManager.Instance.ViewType == ViewType.SideScrolling)
        {
            dashDirection = new Vector3(_moveDirection.x, 0, 0);
        }

        while (elapsedTime < PlayerManager.Instance.Player.Stat.CurrentStat.DashDuration)
        {
            float t = elapsedTime / PlayerManager.Instance.Player.Stat.CurrentStat.DashDuration;
            transform.position = Vector3.Lerp(initialPosition, initialPosition + dashDirection * PlayerManager.Instance.Player.Stat.CurrentStat.DashDistance, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _isDashing = false;
        OnDashEvent?.Invoke(_isDashing);
    }

    private void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }
}
