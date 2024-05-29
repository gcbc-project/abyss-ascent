using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            OnMoveEvent?.Invoke(direction);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            Vector2 direction = Vector2.zero;
            OnMoveEvent?.Invoke(direction);
        }
    }
}
