using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Quaternion CameraRotation { get; private set; }
    private Vector2 _currentRotation = Vector2.zero;
    private float _mouseSpeed = 0.1f;

    private void Start()
    {
        CameraManager.Instance.OnChangeView += ThirdViewAble;
    }

    public void InitializeCurrentRotation()
    {
        Camera camera = Camera.main;
        if (camera != null)
        {
            Vector3 initialRotation = camera.transform.rotation.eulerAngles;
            _currentRotation = new Vector2(initialRotation.y, initialRotation.x);
        }
    }

    private void ThirdViewAble(ViewType viewType)
    {
        if (viewType == ViewType.Third)
        {
            PlayerManager.Instance.Player.Input.OnLookInputEvent += OnLook;
        }
        else
        {
            PlayerManager.Instance.Player.Input.OnLookInputEvent -= OnLook;
        }
    }

    private void OnLook(Vector2 mouseDelta)
    {
        _currentRotation.x += mouseDelta.x * _mouseSpeed;
        _currentRotation.y -= mouseDelta.y * _mouseSpeed;

        CameraRotation = Quaternion.Euler(_currentRotation.y, _currentRotation.x, 0);
    }
}