using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoveInputEvent;
    public event Action<Vector2> OnLookInputEvent;
    public event Action OnJumpInputEvent;
    public event Action OnInteractInputEvent;
    public Action OnAddResource;
    public Action Oninventory;
    public event Action OnDashInputEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            OnMoveInputEvent?.Invoke(direction);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            Vector2 direction = Vector2.zero;
            OnMoveInputEvent?.Invoke(direction);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (CameraManager.Instance.ViewType == ViewType.Top) return;

        if (context.phase == InputActionPhase.Started)
        {
            OnJumpInputEvent?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (CameraManager.Instance._canLook)
        {
            Vector2 mouseDelta = context.ReadValue<Vector2>();
            OnLookInputEvent?.Invoke(mouseDelta);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnInteractInputEvent?.Invoke();
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Oninventory?.Invoke();
            CameraManager.Instance.ToggleCursor();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnDashInputEvent?.Invoke();
        }
    }
}