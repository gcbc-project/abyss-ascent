using UnityEngine;

public class WallClimb : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private LayerMask _groundLayer;
    private float _wallCheckDistance = 0.5f;
    private float _climbSpeed = 3f;
    private bool _isClimbing = false;


    public void Start()
    {
        _groundLayer = LayerMask.GetMask("Ground");
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void LateUpdate()
    {
        CheckForWall();

        if (_isClimbing)
        {
            ClimbWall();
        }
    }

    public void CheckForWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _wallCheckDistance, _groundLayer))
        {
            if (!_isClimbing)
            {
                StartClimbing();
            }
        }
        else
        {
            if (_isClimbing)
            {
                StopClimbing();
            }
        }
    }

    public void StartClimbing()
    {
        _isClimbing = true;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector2.zero;
        _animator.SetBool("isClimbing", true);
    }

    public void StopClimbing()
    {
        _isClimbing = false;
        _rigidbody.useGravity = true;
        _animator.SetBool("isClimbing", false);
    }

    public void ClimbWall()
    {
        Vector3 climbDirection = new Vector3(0, _climbSpeed * Time.deltaTime, 0);
        transform.Translate(climbDirection);
    }

}
