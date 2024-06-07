using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public string GetInteractPrompt()
    {
        string str = "Door";
        return str;
    }

    public void OnInteract()
    {
        Debug.Log("��ȣ �ۿ�");
    }
}
