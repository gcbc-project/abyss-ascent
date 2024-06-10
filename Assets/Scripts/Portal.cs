using System.Collections;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour, IInteractable
{
    public Transform _spawnPoint;
    public GameObject PortalNotice;
    private GameObject _interactingObject;
    private TextMeshProUGUI _portalText;
    private LayerMask _layerMask;

    private bool _isPlayerInRange = false;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Player");

        if (PortalNotice != null)
        {
            PortalNotice.SetActive(false);
            _portalText = PortalNotice.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public string GetInteractPrompt()
    {
        return "Do you want to Teleport? (Y/N)";
    }

    public void OnInteract()
    {
        if (_isPlayerInRange)
        {
            StartCoroutine(HandleInteraction());
        }
    }

    private IEnumerator HandleInteraction()
    {
        string prompt = GetInteractPrompt();
        if (_portalText != null)
        {
            _portalText.text = prompt;
            PortalNotice.SetActive(true);
        }

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Teleport();
                PortalNotice.SetActive(false);
                yield break;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                PortalNotice.SetActive(false);
                yield break;
            }

            yield return null;
        }
    }

    private void Teleport()
    {
        if (_interactingObject != null)
        {
            _interactingObject.transform.position = _spawnPoint.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_layerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            _isPlayerInRange = true;
            _interactingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_layerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            _isPlayerInRange = false;
            _interactingObject = null;
            PortalNotice.SetActive(false);
        }
    }
}