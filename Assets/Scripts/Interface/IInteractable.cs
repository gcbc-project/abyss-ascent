using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt(); // 물체이름과 내용이 적혀있다고 가정

    public void OnInteract(); // 아이템과의 상호작용

}
