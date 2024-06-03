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
    Vector3 GetStartPosition();
    Vector3 GetEndPosition();
    float GetMoveSpeed();
    float GetWaitTime();
    void Move(Vector3 targetPosition);
    bool IsAtPosition(Vector3 position);
}
