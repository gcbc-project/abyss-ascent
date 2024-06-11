using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpwanPoint
{
    public Transform Point;
    public ViewType ViewType;
}

public class SpwanManager : BaseSingleton<SpwanManager>
{
    [SerializeField] List<SpwanPoint> _spawnPoints = new List<SpwanPoint>();
    int _currentPointIndex = 0;

    public void Spawn()
    {
        PlayerManager.Instance.Player.transform.position = _spawnPoints[_currentPointIndex].Point.position;
        PlayerManager.Instance.Player.Health.Modify(100);
        CameraManager.Instance.SetView(_spawnPoints[_currentPointIndex].ViewType);
    }

    public void SetNextSpawn()
    {
        if (_currentPointIndex + 1 < _spawnPoints.Count)
        {
            _currentPointIndex++;
        }
    }
}
