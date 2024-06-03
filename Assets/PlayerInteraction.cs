using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private LayerMask _layerMask = LayerMask.GetMask("Interactable");
    private IInteractable _interactable;
    private GameObject _interactingGameObject;

    private float _coolTime = 0.05f;
    private float _lastInteractTime;
    private float _maximumInteractDistance = 5f;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;   // Tag = MainCamera
    }

    private void Update()
    {
        if((Time.time - _lastInteractTime) > _coolTime)
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

    public void OnInteractInput(InputAction.CallbackContext context)   //  상호작용 이벤트 E 버튼
    {
        if(context.phase == InputActionPhase.Started && _interactable != null)
        {
            _interactable.OnInteract();
            _interactingGameObject = null;
            _interactable = null;
            
        }
    }
}
