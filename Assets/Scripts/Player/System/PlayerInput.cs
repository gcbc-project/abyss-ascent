using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public enum ControlMode { ThirdPerson, TopView, SideScroller }
    public ControlMode currentMode = ControlMode.ThirdPerson;

    public event Action<Vector2> OnMoveInputEvent;
    public event Action OnJumpInputEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            if (currentMode == ControlMode.SideScroller) //Ⱦ��ũ���϶� ���Ʒ� ����Ű ��Ȱ��
            {
                direction.y = 0;
            }

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
        if (currentMode == ControlMode.TopView) //ž������϶� ���� ��Ȱ��
        {
            return;
        }

        if (context.phase == InputActionPhase.Started)
        {
            OnJumpInputEvent?.Invoke();
        }
    }
}