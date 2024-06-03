using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour,IMovingObject
{
    [SerializeField] MoveDir dir;
    [SerializeField] float moveSpeed;
    [SerializeField] float waitTime;
    [SerializeField] float moveDistance;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool _movingToEnd = true;

    void Start()
    {
        _startPosition = gameObject.transform.position;
        MoveDirection(dir);
        StartCoroutine(MoveFloor());
    }

    public Vector3 GetStartPosition() => _startPosition;
    public MoveDir Dir => dir;
    public float GetMoveSpeed() => moveSpeed;
    public float GetWaitTime() => waitTime;

    public Vector3 GetEndPosition() => _endPosition;


    void MoveDirection(MoveDir dir)
    {
        switch(dir){
            case MoveDir.MoveToX:
                _endPosition = _startPosition + new Vector3(moveDistance,0,0);
                break;
            case MoveDir.MoveToY:
                _endPosition = _startPosition + new Vector3(0, moveDistance, 0);
                break;
            case MoveDir.MoveToZ:
                _endPosition = _startPosition + new Vector3(0, 0, moveDistance);
                break;
        }
    }
    
    public void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public bool IsAtPosition(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) <= 0.1f;
    }

    IEnumerator MoveFloor()
    {
        while (true)
        {
            Vector3 targetPosition = _movingToEnd ? _endPosition : _startPosition;
            while (!IsAtPosition(targetPosition))
            {
                Move(targetPosition);
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);

            _movingToEnd = !_movingToEnd;
        }
    }
}
