using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PlayerManager.Instance.Player.Input.OnMoveEvent += OnMove;
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
        float speed = 100;

        Vector3 direction = transform.forward * _direction.y + transform.right * _direction.x;
        direction.y = _rigidbody.velocity.y;

        _rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
