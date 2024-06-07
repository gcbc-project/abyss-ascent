using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ResourceSlot[] _slots;
    [SerializeField] Transform _slotPanel;

    [Header("Selected Item")]
    ResourceSlot _selectedItem;
    [SerializeField] TMP_Text _selectedItemName;
    [SerializeField] TMP_Text _selectedItemDescription;

    private void Start()
    {
        PlayerManager.Instance.Player.Input.Oninventory += Toggle;
        PlayerManager.Instance.Player.Input.OnAddResource += AddItem;

        gameObject.SetActive(false);

        _slots = new ResourceSlot[_slotPanel.childCount];

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = _slotPanel.GetChild(i).GetComponent<ResourceSlot>();
            _slots[i].Idx = i;
            _slots[i].Inventory = this;
            _slots[i].Clear();
        }

        ClearSelectedItemInfo();
    }

    private void ClearSelectedItemInfo()
    {
        _selectedItemDescription.text = string.Empty;
        _selectedItemName.text = string.Empty;
    }

    private void Toggle()
    {
        gameObject.SetActive(!IsOpen());
    }

    private bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }

    private void AddItem()
    {
        ResourceData resourceData = PlayerManager.Instance.Player.ResourceData;
        ResourceSlot emptySlot = GetemptySlot();

        if (resourceData == null)
        {
            return;
        }

        if (emptySlot != null)
        {
            emptySlot.Data = resourceData;
            UpdateUI();
            PlayerManager.Instance.Player.ResourceData = null;
        }
    }

    private ResourceSlot GetemptySlot()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].Data == null)
            {
                return _slots[i];
            }
        }
        return null;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].Data != null)
            {
                _slots[i].Set();
            }
            else
            {
                _slots[i].Clear();
            }
        }
    }

    public void SelectItem(int index)
    {
        if (_slots[index].Data == null) return;

        if (_selectedItem == _slots[index])
        {
            ClearSelectedItemWindow();
            return;
        }

        if (_selectedItem != null)
        {
            _selectedItem.DisableOutline();
        }

        _selectedItem = _slots[index];

        _selectedItemName.text = _selectedItem.Data._resourceName;
        _selectedItemDescription.text = _selectedItem.Data._resourceDescription;
        _selectedItem.EnableOutline();
    }

    private void ClearSelectedItemWindow()
    {
        if (_selectedItem != null)
        {
            _selectedItem.DisableOutline();
        }
        _selectedItem = null;
        _selectedItemName.text = string.Empty;
        _selectedItemDescription.text = string.Empty;
    }
}