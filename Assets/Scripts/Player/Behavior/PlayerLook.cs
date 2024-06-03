using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _cameraOffset;
    private float _distance = 4.0f;
    private float _yOffset = 1.0f;

    private void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        _cameraOffset = new Vector3(0.0f, _yOffset, -_distance);
    }
    private void LateUpdate()
    {
        //마우스 카메라 x
        Quaternion cameraRotation = Quaternion.Euler(20f, 0f, 0f);
        Vector3 position = cameraRotation * _cameraOffset + transform.position;

        _camera.transform.rotation = cameraRotation;
        _camera.transform.position = position;
    }
}
