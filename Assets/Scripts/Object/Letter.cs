using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour, IInteractable
{
    public string GetInteractPrompt()
    {
        string text = "Letter \n\n No pain No gain";
        return text;
    }

    public void OnInteract()
    {
        // 예를들면 인벤에 템을 보관한다는 메서드를 넣는다던지

        Destroy(gameObject);
    }
}
