using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt(); // ��ü�̸��� ������ �����ִٰ� ����

    public void OnInteract(); // �����۰��� ��ȣ�ۿ�

}
