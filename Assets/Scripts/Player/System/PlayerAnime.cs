using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _isJumping = Animator.StringToHash("isJumping");
    private readonly int _jumpNum = Animator.StringToHash("jumpNum");
    private readonly int _isFalling = Animator.StringToHash("isFalling");
    private readonly int _isGrounded = Animator.StringToHash("isGrounded");
    private readonly int _isDashing = Animator.StringToHash("isDashing");
    private readonly int _isClimbing = Animator.StringToHash("isClimbing");

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += OnMove;

        PlayerManager.Instance.Player.Jump.OnJumpEvent += OnJump;
        PlayerManager.Instance.Player.Jump.OnFallingEvent += OnFalling;
        PlayerManager.Instance.Player.Jump.OnGroundedEvent += OnGrounded;
        PlayerManager.Instance.Player.Dash.OnDashEvent += OnDash;
        PlayerManager.Instance.Player.Climb.OnClimbEvent += OnClimb;
        PlayerManager.Instance.Player.Climb.OnClimbingEvent += OnClimbing;
    }

    private void OnClimbing(float magnitude)
    {
        if (magnitude < 0.01f)
        {
            _animator.speed = 0f;
        }
        else
        {
            _animator.speed = 1f;
        }
    }
    private void OnClimb(bool isClimbing)
    {
        _animator.SetBool(_isClimbing, isClimbing);
    }
    private void OnDash(bool isDashing)
    {
        _animator.SetBool(_isDashing, isDashing);
    }
    private void OnJump(bool isJumping, int jumpNum)
    {
        if (jumpNum > 1)
        {
            _animator.Play("Double Jump", -1, 0f);
        }
        _animator.SetBool(_isJumping, isJumping);
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
