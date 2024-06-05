using UnityEngine;
using UnityEngine.InputSystem;

public class DodgeDash : MonoBehaviour
{
    [SerializeField] private float _dashDistance = 5f;
    [SerializeField] private float _dashDuration = 0.5f;
    [SerializeField] private float _dashCooldown = 1f;
    //private Animator _animator;
    private bool _isDashing = false;
    private bool _canDash = true;
    private bool _isMoving = false; // 플레이어가 움직이고 있는지 여부
    private Vector3 _dashDirection;
    private InputAction _dashAction;
    private InputAction _moveAction;

    private void Awake()
    {
        _dashAction = new InputAction("Dodge", InputActionType.Button, "<Keyboard>/leftShift"); // 왼쪽 쉬프트 키와 연결
        _moveAction = new InputAction("Move", InputActionType.Value, "<Keyboard>/w");
        _moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
                                                                                                
        _dashAction.Enable();
        _moveAction.Enable();

        _dashAction.started += ctx => StartDashing(ctx);
        _moveAction.performed += ctx => UpdateMovementState(ctx);
        _moveAction.canceled += ctx => UpdateMovementState(ctx);
    }

    private void OnDestroy()
    {
        _dashAction.Disable();
        _moveAction.Disable();
    }

    private void Update()
    {
        if (_isDashing)
        {
            // 애니메이션

            transform.position += _dashDirection * _dashDistance * Time.deltaTime / _dashDuration;
        }
    }

    private void StartDashing(InputAction.CallbackContext context)
    {
        if (!_isDashing && _canDash && _isMoving && context.started)
        {
            _isDashing = true;
            _canDash = false;
            _dashDirection = transform.forward;
            Invoke("StopDashing", _dashDuration);
            Invoke("ResetDash", _dashCooldown);
        }
    }

    private void StopDashing()
    {
        _isDashing = false;
    }

    private void ResetDash()
    {
        _canDash = true;
    }

    private void UpdateMovementState(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        _isMoving = movementInput != Vector2.zero;
    }
}
