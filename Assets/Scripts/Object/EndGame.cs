using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour, IInteractable
{
    [SerializeField] string _keyId;  // 문을 열기 위한 키 ID
    [SerializeField] Image image;

    public string GetInteractPrompt()
    {
        return "보물상자 열기";
    }

    public void OnInteract()
    {
        foreach (InventorySlot slot in PlayerManager.Instance.Player.Inventory.Slots)
        {
            // 슬롯에 데이터가 있고 데이터가 ResourceKeySO인지 확인
            if (slot.Data != null && slot.Data is ResourceKeySO keyData)
            {
                if (_keyId == keyData.KeyId)
                {
                    slot.Inventory.RemoveItem(keyData);
                    Open();
                    return; // 문이 열리면 더 이상 반복하지 않음
                }
            }
        }
    }

    public void Open()
    {
        image.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
