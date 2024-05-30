using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _currentRotation = Vector2.zero;
    private Quaternion _cameraRotation;
    private float _distance = 4.0f;
    private float _mouseSpeed = 0.1f;
    private float _yOffset = 1.0f;

    private void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerManager.Instance.Player.Input.OnLookEvent += OnLook;
    }
    private void LateUpdate()
    {
        if (_cameraRotation != null)
        {
            Vector3 position = _cameraRotation * new Vector3(0.0f, 0.0f, -_distance) + transform.position;
            position.y += _yOffset;

            _camera.transform.rotation = _cameraRotation;
            _camera.transform.position = position;
        }
    }
    private void OnLook(Vector2 mouseDelta)
    {
        _currentRotation.x += mouseDelta.x * _mouseSpeed;
        _currentRotation.y -= mouseDelta.y * _mouseSpeed;

        _cameraRotation = Quaternion.Euler(_currentRotation.y, _currentRotation.x, 0);
    }
}
