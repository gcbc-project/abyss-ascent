using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDir
{
    MoveToX,
    MoveToY,
    MoveToZ
}
public interface IMovingObject
{
    public MoveDir Dir { get; }
    public Vector3 GetStartPosition();
    public Vector3 GetEndPosition();
    public float GetMoveSpeed();
    public float GetWaitTime();
    public void Move(Vector3 targetPosition);
    public bool IsAtPosition(Vector3 position);
    public event Action<Vector3> MovingFloorEvent;
}
