using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceObject : MonoBehaviour, IInteractable
{
    public ResourceData _data;

    public string GetInteractPrompt()
    {
        string str = $"{_data._resourceName}";
        return str;
    }

    public void OnInteract()
    {
        PlayerManager.Instance.Player.ResourceData = _data;
        PlayerManager.Instance.Player.Input.OnAddResource?.Invoke();
        Destroy(gameObject);
    }
}
