using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 _direction;
    private Camera _camera;
    private Vector3 _beforeDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        PlayerManager.Instance.Player.Input.OnMoveInputEvent += OnMove;
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
        if (_direction.magnitude < 0.1f)
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            return;
        }

        Vector3 moveDirection = CalculateMoveDirection();
        moveDirection *= PlayerManager.Instance.Player.Stat.CurrentStat.WalkSpeed;
        moveDirection.y = _rigidbody.velocity.y;

        _rigidbody.velocity = moveDirection;

        if (moveDirection != Vector3.zero)
        {
            RotateToMoveDirection(moveDirection);
        }
    }


    private void RotateToMoveDirection(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 20);
    }

    private Vector3 CalculateMoveDirection()
    {
        if (CameraManager.Instance.ViewType == ViewType.Third)
        {
            Vector3 forward = _camera.transform.forward;
            Vector3 right = _camera.transform.right;
            forward.y = 0;
            right.y = 0;
            return (forward.normalized * _direction.y + right.normalized * _direction.x).normalized;
        }
        else if (CameraManager.Instance.ViewType == ViewType.Top)
        {
            return new Vector3(_direction.x, 0, _direction.y).normalized;
        }
        else
        {
            return new Vector3(_direction.x, _direction.y, 0).normalized;
        }
    }

    private void OnMovingFloor(Vector3 deltaMovement)
    {
        // 플레이어에 변위를 적용합니다.
        transform.position += deltaMovement;
    }
    private void OnCollisionEnter(Collision collision)
    {
        IMovingObject movingObject = collision.gameObject.GetComponent<IMovingObject>();
        if (movingObject != null)
        {
            movingObject.MovingFloorEvent += OnMovingFloor;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        IMovingObject movingObject = collision.gameObject.GetComponent<IMovingObject>();
        if (movingObject != null)
        {
            movingObject.MovingFloorEvent -= OnMovingFloor;
        }
    }
}
