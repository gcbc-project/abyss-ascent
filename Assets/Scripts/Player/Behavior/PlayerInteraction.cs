using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action<IInteractable> OnInterectEnterEvent;
    public Action<IInteractable> OnInterectExitEvent;

    private LayerMask _layerMask;
    private IInteractable _interactable;
    private GameObject _interactingGameObject;

    private float _coolTime = 0.05f;
    private float _lastInteractTime;

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Interactable");
        PlayerManager.Instance.Player.Input.OnInteractInputEvent += OnInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((Time.time - _lastInteractTime) > _coolTime)
        {
            _lastInteractTime = Time.time;

            if (((1 << other.gameObject.layer) & _layerMask) != 0)
            {
                if (other.gameObject != _interactingGameObject)
                {
                    _interactingGameObject = other.gameObject;
                    _interactable = other.GetComponent<IInteractable>();
                    OnInterectEnterEvent.Invoke(_interactable);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _interactingGameObject)
        {
            OnInterectExitEvent.Invoke(_interactable);
            ClearInteraction();
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
            OnInterectExitEvent.Invoke(_interactable);
            _interactable.OnInteract();
            _interactingGameObject = null;
            _interactable = null;
        }
    }
}
