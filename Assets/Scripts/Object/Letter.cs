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
        // ������� �κ��� ���� �����Ѵٴ� �޼��带 �ִ´ٴ���

        Destroy(gameObject);
    }
}
