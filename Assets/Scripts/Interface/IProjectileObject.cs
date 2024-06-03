using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileObject
{
    public float MoveSpeed { get; }
    void SetDirection(Vector3 direction);
}
