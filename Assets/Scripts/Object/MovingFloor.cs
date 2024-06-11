using System;
using System.Collections;
using UnityEngine;

public class MovingFloor : MonoBehaviour, IMovingObject
{
    [SerializeField] MoveDir dir;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _waitTime;
    [SerializeField] float _moveDistance;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool _movingToEnd = true;
    private Vector3 _previousPosition; // 이전 위치 추적
    public event Action<Vector3> MovingFloorEvent;

    void Start()
    {
        _startPosition = gameObject.transform.position;
        MoveDirection(dir);
        _previousPosition = _startPosition; // 이전 위치 초기화
        StartCoroutine(MoveFloor());
    }

    public Vector3 GetStartPosition() => _startPosition;
    public MoveDir Dir => dir;
    public float GetMoveSpeed() => _moveSpeed;
    public float GetWaitTime() => _waitTime;

    public Vector3 GetEndPosition() => _endPosition;


    void MoveDirection(MoveDir dir)
    {
        switch (dir)
        {
            case MoveDir.MoveToX:
                _endPosition = _startPosition + new Vector3(_moveDistance, 0, 0);
                break;
            case MoveDir.MoveToY:
                _endPosition = _startPosition + new Vector3(0, _moveDistance, 0);
                break;
            case MoveDir.MoveToZ:
                _endPosition = _startPosition + new Vector3(0, 0, _moveDistance);
                break;
        }
    }

    public void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
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
                Vector3 deltaMovement = transform.position - _previousPosition;
                _previousPosition = transform.position;

                // 플레이어에게 (있는 경우) 이동 변위 알림
                MovingFloorEvent?.Invoke(deltaMovement);
                yield return null;
            }
            yield return new WaitForSeconds(_waitTime);

            _movingToEnd = !_movingToEnd;
        }
    }
}
