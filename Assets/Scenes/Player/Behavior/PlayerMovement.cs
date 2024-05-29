using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private LayerMask _groundLayerMask;
    private Rigidbody _rigidbody;
    private Vector2 _direction;
    private float _radius = 0.1f;
    private float _offset = 0.5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PlayerManager.Instance.Player.Input.OnMoveEvent += OnMove;
        PlayerManager.Instance.Player.Input.OnJumpEvent += OnJump;
        _groundLayerMask = LayerMask.GetMask("Ground");
    }

    private void OnJump()
    {
        if (IsGrounded())
        {
            // TODO: Jump 관련 변수를 Stat에서 가져오도록 수정
            float jumpPower = 150f;
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }


    private void OnMove(Vector2 vector)
    {
        _direction = vector;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // TODO: Speed를 Stat에서 가져오도록 수정
        float speed = 5;

        Vector3 vector = transform.forward * _direction.y + transform.right * _direction.x;
        vector *= speed;
        vector.y = _rigidbody.velocity.y;

        _rigidbody.velocity = vector;
    }

    private bool IsGrounded()
    {
        Vector3 startPoint = transform.position + Vector3.up * _radius - new Vector3(0, _offset, 0);
        Vector3 direction = -Vector3.up;

        if (Physics.SphereCast(startPoint, _radius, direction, out RaycastHit hit, _radius, _groundLayerMask))
        {
            return true;
        }
        return false;
    }
}
