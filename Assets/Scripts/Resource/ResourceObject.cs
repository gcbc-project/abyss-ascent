using UnityEngine;


public class ResourceObject : MonoBehaviour, IInteractable
{
    public ResourceData _data;

    public string GetInteractPrompt()
    {
        string str = $"{_data.ResourceName}";
        return str;
    }

    public void OnInteract()
    {
        PlayerManager.Instance.Player.ResourceData = _data;
        PlayerManager.Instance.Player.Input.OnAddResource?.Invoke();
        Destroy(gameObject);
    }
}
