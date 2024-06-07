using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _jumping = Animator.StringToHash("jumping");
    private readonly int _jumpNum = Animator.StringToHash("jumpNum");
    private readonly int _isFalling = Animator.StringToHash("isFalling");
    private readonly int _isGrounded = Animator.StringToHash("isGrounded");

    private Animator _animator;
    private PlayerJump _playerJump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += OnMove;
        PlayerManager.Instance.Player.Jump.OnJumpEvent += OnJump;
        PlayerManager.Instance.Player.Jump.OnFallingEvent += OnFalling;
        PlayerManager.Instance.Player.Jump.OnGroundedEvent += OnGrounded;
    }

    private void OnJump(bool isJumping, int jumpNum)
    {
        if (jumpNum > 1)
        {
            _animator.Play("Double Jump", -1, 0f);
        }
        _animator.SetBool(_jumping, isJumping);
        _animator.SetInteger(_jumpNum, jumpNum);
    }
    private void OnFalling(bool isFalling)
    {
        _animator.SetBool(_isFalling, isFalling);
    }
    private void OnGrounded(bool isGrounded)
    {
        _animator.SetBool(_isGrounded, isGrounded);
    }

    private void OnMove(Vector2 direction)
    {
        _animator.SetBool(_isWalk, direction.magnitude > 0f);
    }
}
