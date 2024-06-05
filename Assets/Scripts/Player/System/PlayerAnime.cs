using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _jump = Animator.StringToHash("jump");
    private readonly int _isFalling = Animator.StringToHash("isFalling");
    private readonly int _isGrounded = Animator.StringToHash("isGrounded");

    private Animator _animator;
    private PlayerJump _playerJump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerJump = GetComponent<PlayerJump>();
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += OnMove;
        _playerJump.OnJumpEvent += OnJump;
        _playerJump.OnFallingEvent += OnFalling;
        _playerJump.OnGroundedEvent += OnGrounded;
    }

    private void OnJump()
    {
        _animator.SetTrigger(_jump);
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
