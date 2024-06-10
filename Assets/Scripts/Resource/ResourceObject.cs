using UnityEngine;


public class ResourceObject : MonoBehaviour, IInteractable
{
    public ResourceSO Data;

    public string GetInteractPrompt()
    {
        string str = $"{Data.Name}";
        return str;
    }

    public void OnInteract()
    {
        PlayerManager.Instance.Player.Input.OnAddResource?.Invoke(Data);
        Destroy(gameObject);
    }
}
