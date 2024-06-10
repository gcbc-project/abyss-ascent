using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [HideInInspector] public PlayerInvnetoryUI InventoryUI;
    [HideInInspector] public ResourceSO Data;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemName;

    public void SetData(ResourceSO data)
    {
        Data = data;

        if (Data != null)
        {
            _icon.sprite = Data.Icon;
            // _itemName.text = _data.Name;
            _icon.gameObject.SetActive(true);
        }
        else
        {
            Clear();
        }
    }

    public void Clear()
    {
        Data = null;
        _icon.sprite = null;
        // _itemName.text = "";
        _icon.gameObject.SetActive(false);
    }

    public void OnClickButton()
    {
        // Inventory.SelectItem(Idx);
        InventoryUI.SelectItem(this);
    }

}
