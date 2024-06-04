using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public string GetInteractPrompt()
    {
        string text = "Open door \n\n press 'E'";
        string coloredText = text.Replace("E", "<color=#FF0000>E</color>");
        return coloredText;
    }

    public void OnInteract()
    {
        Debug.Log("도어와 상호 작용 합니다");
    }
}
