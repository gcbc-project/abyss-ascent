using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ResourceSlot[] _slots;
    public GameObject _inventory;
    public Transform _slotPanel;

    private PlayerInput _playerInput;

    [Header("Selected Item")]
    private ResourceSlot _selectedItem;
    private int _selectedItemIndex;
    public TMP_Text _selectedItemName;
    public TMP_Text _selectedItemDescription;

    private void Start()
    {
        _playerInput = PlayerManager.Instance.Player.Input;

        _playerInput.Oninventory += Toggle;
        PlayerManager.Instance.Player.Input.OnAddResource += AddItem;

        _inventory.SetActive(false);

        _slots = new ResourceSlot[_slotPanel.childCount];

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = _slotPanel.GetChild(i).GetComponent<ResourceSlot>();
            _slots[i]._index = i;
            _slots[i]._inventory = this;
            _slots[i].Clear();
        }

        ClearSelectedItemInfo();
    }

    private void ClearSelectedItemInfo()
    {
        _selectedItemDescription.text = string.Empty;
        _selectedItemName.text = string.Empty;
    }

    public void Toggle()
    {
        _inventory.SetActive(!IsOpen());
    }

    public bool IsOpen()
    {
        return _inventory.activeInHierarchy;
    }

    public void AddItem()
    {
        ResourceData resourceData = PlayerManager.Instance.Player.ResourceData;
        ResourceSlot emptySlot = GetemptySlot();

        if (resourceData == null)
        {
            return;
        }

        if (emptySlot != null)
        {
            emptySlot._data = resourceData;
            UpdateUI();
            PlayerManager.Instance.Player.ResourceData = null;
        }
    }

    ResourceSlot GetemptySlot()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i]._data == null)
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
            if (_slots[i]._data != null)
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
        if (_slots[index]._data == null) return;

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
        _selectedItemIndex = index;

        _selectedItemName.text = _selectedItem._data._resourceName;
        _selectedItemDescription.text = _selectedItem._data._resourceDescription;
        _selectedItem.EnableOutline();
    }

    void ClearSelectedItemWindow()
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