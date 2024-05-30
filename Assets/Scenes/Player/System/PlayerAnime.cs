using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _jump = Animator.StringToHash("jump");

    private Animator _animator;
    private PlayerJump _playerJump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerJump = GetComponent<PlayerJump>();
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += OnMove;
        _playerJump.OnJumpEvent += OnJump;
    }

    private void OnJump()
    {
        _animator.SetTrigger(_jump);
    }

    private void OnMove(Vector2 direction)
    {
        _animator.SetBool(_isWalk, direction.magnitude > 0f);
    }
}
