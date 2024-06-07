using System;
using System.Collections;
using UnityEngine;

public enum ViewType
{
    Top = 1 << 8,
    Third = 1 << 9,
    SideScrolling,
}

public class CameraManager : BaseSingleton<CameraManager>
{
    public ViewType ViewType { get; private set; }
    public event Action<ViewType> OnChangeView;

    private Camera _camera;
    private Transform _playerTransform;
    private Coroutine _currentSwitchCoroutine;
    private bool _isSwitchingView;
    private float _distance = 4.0f;
    private float _yOffset = 1.0f;

    private void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        _playerTransform = PlayerManager.Instance.Player.transform;
        SetView(ViewType.SideScrolling);
    }

    public void SetView(ViewType type)
    {
        if (ViewType != type)
        {
            ViewType = type;
            if (_currentSwitchCoroutine != null)
            {
                StopCoroutine(_currentSwitchCoroutine);
            }
            _currentSwitchCoroutine = StartCoroutine(SwitchView(type));
            OnChangeView?.Invoke(type);
        }
    }

    private IEnumerator SwitchView(ViewType type)
    {
        _isSwitchingView = true;

        Vector3 startPosition = _camera.transform.position;
        Quaternion startRotation = _camera.transform.rotation;

        Vector3 targetPosition = startPosition;
        Quaternion targetRotation = startRotation;

        switch (type)
        {
            case ViewType.Top:
                targetRotation = Quaternion.Euler(70, 0, 0);
                break;
            case ViewType.SideScrolling:
                targetRotation = Quaternion.Euler(0, 0, 0);
                break;
            case ViewType.Third:
                targetRotation = Quaternion.Euler(60, -2.6f, 0);
                break;
        }

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            // 플레이어 위치를 지속적으로 반영하여 목표 위치 갱신
            switch (type)
            {
                case ViewType.Top:
                    targetPosition = new Vector3(_playerTransform.position.x, 6, _playerTransform.position.z - 1);
                    break;
                case ViewType.SideScrolling:
                    targetPosition = new Vector3(_playerTransform.position.x, 0.5f + _playerTransform.position.y, -10);
                    break;
                case ViewType.Third:
                    targetPosition = new Vector3(_playerTransform.position.x, 4, _playerTransform.position.z - 2);
                    break;
            }

            _camera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            _camera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            yield return null;
        }

        _camera.transform.position = targetPosition;
        _camera.transform.rotation = targetRotation;

        PlayerManager.Instance.Player.Look.InitializeCurrentRotation();
        _isSwitchingView = false;
    }

    private void LateUpdate()
    {
        if (_isSwitchingView)
        {
            return;
        }

        switch (ViewType)
        {
            case ViewType.Top:
                _camera.transform.rotation = Quaternion.Euler(70, 0, 0);
                _camera.transform.position = new Vector3(_playerTransform.position.x, 6, _playerTransform.position.z - 1);
                break;
            case ViewType.SideScrolling:
                _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
                _camera.transform.position = new Vector3(_playerTransform.position.x, 0.5f + _playerTransform.position.y, -10);
                break;
            case ViewType.Third:
                if (PlayerManager.Instance.Player.Look.CameraRotation != null)
                {
                    Vector3 position = PlayerManager.Instance.Player.Look.CameraRotation * new Vector3(0.0f, 0.0f, -_distance) + _playerTransform.position;
                    position.y += _yOffset;

                    _camera.transform.rotation = PlayerManager.Instance.Player.Look.CameraRotation;
                    _camera.transform.position = position;
                }
                break;
        }
    }
}
