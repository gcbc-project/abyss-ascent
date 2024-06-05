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
                targetPosition = new Vector3(_playerTransform.position.x, 6, _playerTransform.position.z - 1);
                targetRotation = Quaternion.Euler(70, 0, 0);
                break;
            case ViewType.SideScrolling:
                targetPosition = new Vector3(_playerTransform.position.x, 0.5f + _playerTransform.position.y, -10);
                targetRotation = Quaternion.Euler(0, 0, 0);
                break;
            case ViewType.Third:
                targetPosition = new Vector3(_playerTransform.position.x, 4, _playerTransform.position.z - 2);
                targetRotation = Quaternion.Euler(60, -2.6f, 0);
                break;
        }

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            _camera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            _camera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        _camera.transform.position = targetPosition;
        _camera.transform.rotation = targetRotation;

        _isSwitchingView = false;
    }

    private void LateUpdate()
    {
        if (_isSwitchingView)
        {
            return;
        }

        if (ViewType == ViewType.Top)
        {
            _camera.transform.rotation = Quaternion.Euler(70, 0, 0);
            _camera.transform.position = new Vector3(_playerTransform.position.x, 6, _playerTransform.position.z - 1);
        }
        else if (ViewType == ViewType.SideScrolling)
        {
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.position = new Vector3(_playerTransform.position.x, 0.5f + _playerTransform.position.y, -10);
        }
    }
}
