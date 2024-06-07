using System.Collections;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private LayerMask _groundLayer;

    private readonly int a_isClimbing = Animator.StringToHash("isClimbing");
    private readonly int a_isClimbTop = Animator.StringToHash("isClimbTop");

    private float rayDistance = 0.4f;
    private float climbSpeed = 1f;
    private float topOffset = 1.05f;  // Distance to move the player up at the top
    private float forwardOffset = 0.5f;  // Distance to move the player forward after climbing

    private bool isClimbing = false;

    public void Start()
    {
        _groundLayer = LayerMask.GetMask("Ground");
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (isClimbing)
        {
            ClimbCheck();
            ClimbWall();
        }
        else
        {
            CheckForWall();
        }
    }

    private void CheckForWall()
    {
        if (RayHit(transform.position + Vector3.up * 0.5f))
        {
            StartClimbing();
        }
    }

    private void ClimbCheck()
    {
        bool bodyRayHit = RayHit(transform.position + Vector3.up * 0.5f);
        bool headRayHit = RayHit(transform.position + Vector3.up * 1.0f);

        if (!headRayHit && bodyRayHit)
        {
            ClimbTop();
        }
        else if (!bodyRayHit)
        {
            StopClimbing();
        }
    }

    private bool RayHit(Vector3 startPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(startPos, transform.forward, out hit, rayDistance, _groundLayer))
        {
            return true;
        }
        return false;
    }

    private void StartClimbing()
    {
        isClimbing = true;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _animator.SetBool(a_isClimbing, true);
        _animator.SetBool(a_isClimbTop, false);  // Climbing started, not at the top yet
    }

    private void ClimbTop()
    {
        _animator.SetBool(a_isClimbTop, true);
        StartCoroutine(MoveToPosition());
    }

    private void StopClimbing()
    {
        isClimbing = false;
        _rigidbody.useGravity = true;
        _animator.SetBool(a_isClimbing, false);
        _animator.SetBool(a_isClimbTop, false);
    }

    private void ClimbWall()
    {
        Vector3 climbDirection = Vector3.up * climbSpeed * Time.deltaTime;
        transform.Translate(climbDirection);
    }

    private IEnumerator MoveToPosition()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.up * topOffset;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        // Wait until the player reaches the top position
        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            float distCovered = (Time.time - startTime) * climbSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        // Move the player forward after reaching the top position
        Vector3 forwardTargetPosition = transform.position + transform.forward * forwardOffset;
        float forwardJourneyLength = Vector3.Distance(transform.position, forwardTargetPosition);
        startTime = Time.time;

        while (Vector3.Distance(transform.position, forwardTargetPosition) > 0.05f)
        {
            Debug.Log(Vector3.Distance(transform.position, targetPosition));
            float distCovered = (Time.time - startTime) * climbSpeed;
            float fractionOfJourney = distCovered / forwardJourneyLength;
            transform.position += transform.forward * climbSpeed * Time.deltaTime;
            yield return null;
        }

        // Stop climbing after completing both movements
        StopClimbing();
    }


}
