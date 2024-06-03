using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private LayerMask _layerMask;
    private IInteractable _interactable;
    private GameObject _interactingGameObject;

    private float _coolTime = 0.05f;
    private float _lastInteractTime;
    private float _maximumInteractDistance = 5f;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;   // Tag = MainCamera
        _layerMask = LayerMask.GetMask("Interactable");
        PlayerManager.Instance.Player.Input.OnInteractInputEvent += OnInteract;
    }

    private void Update()
    {
        if ((Time.time - _lastInteractTime) > _coolTime)
        {
            _lastInteractTime = Time.time;

            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint, _maximumInteractDistance, _layerMask))
            {
                if (hitPoint.collider.gameObject != _interactingGameObject)
                {
                    _interactingGameObject = hitPoint.collider.gameObject;
                    _interactable = hitPoint.collider.GetComponent<IInteractable>();

                }
            }
            else
            {
                ClearInteraction();
            }
        }
    }


    private void ClearInteraction()
    {
        _interactingGameObject = null;
        _interactable = null;

    }

    private void OnInteract()
    {
        if (_interactable != null)
        {
            _interactable.OnInteract();
            _interactingGameObject = null;
            _interactable = null;
        }
    }
}
