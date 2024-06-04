using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public LayerMask GroundLayer;
    public float wallCheckDistance = 0.5f;
    public float climbSpeed = 3f;
    public Animator animator;
    private Vector2 _direction;

    private Rigidbody rb;
    private bool isClimbing = false;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void LateUpdate()
    {
        CheckForWall();

        if (isClimbing)
        {
            ClimbWall();
        }
    }

    public void CheckForWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, wallCheckDistance, GroundLayer))
        {
            if (!isClimbing)
            {
                StartClimbing();
            }
        }
        else
        {
            if (isClimbing)
            {
                StopClimbing();
            }
        }
    }

    public void StartClimbing()
    {
        isClimbing = true;
        rb.useGravity = false;
        rb.velocity = Vector2.zero;
        animator.SetBool("isClimbing", true);
    }

    public void StopClimbing()
    {
        isClimbing = false;
        rb.useGravity = true;
        animator.SetBool("isClimbing", false);
    }

    public void ClimbWall()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 climbDirection = new Vector3(0, vertical * climbSpeed * Time.deltaTime, 0);
        transform.Translate(climbDirection);
    }
    private void OnMove(Vector2 vector)
    {
        _direction = vector;
    }
}
