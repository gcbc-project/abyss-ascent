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
        this.transform.position = new Vector3(7f, 2.51f, 5f);
    }
}
