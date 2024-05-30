using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 _direction;
    private Camera _camera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        PlayerManager.Instance.Player.Input.OnMoveEvent += OnMove;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(Vector2 vector)
    {
        _direction = vector;
    }

    private void Move()
    {
        // TODO: Speed를 Stat에서 가져오도록 수정
        float speed = 5;
        if (_direction.magnitude < 0.5f) return;

        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * _direction.y + right * _direction.x;
        moveDirection *= speed;
        moveDirection.y = _rigidbody.velocity.y;

        _rigidbody.velocity = moveDirection;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 20);
        }
    }
}
