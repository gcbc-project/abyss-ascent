using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInvnetoryUI : MonoBehaviour
{
    [SerializeField] GameObject _uiContainer;
    [SerializeField] Transform _slotContainer;
    [SerializeField] GameObject _slotPrefab;
    private PlayerInventory _playerInventory;
    private List<InventorySlotUI> _slotUIs = new List<InventorySlotUI>();
    private InventorySlotUI _selectedSlot;
    [SerializeField] TMP_Text _selectedItemName;
    [SerializeField] TMP_Text _selectedItemDescription;

    private void Start()
    {
        _playerInventory = PlayerManager.Instance.Player.Inventory;
        PlayerManager.Instance.Player.Input.OnInventoryInputEvent += Toggle;
        _playerInventory.OnInventoryChanged += UpdateInventoryUI;

        CreateSlotUIs();
        _playerInventory.InitializeSlots();

        _uiContainer.SetActive(false);
    }

    private void CreateSlotUIs()
    {
        for (int i = 0; i < _playerInventory.SlotCount; i++)
        {
            GameObject slotObject = Instantiate(_slotPrefab, _slotContainer);
            InventorySlotUI slotUI = slotObject.GetComponent<InventorySlotUI>();
            slotUI.InventoryUI = this;
            _slotUIs.Add(slotUI);
        }
    }

    private void Toggle()
    {
        _uiContainer.SetActive(!_uiContainer.activeInHierarchy);
        ClearSelectedItemWindow();
    }

    private void UpdateInventoryUI()
    {
        InventorySlot[] slots = _playerInventory.Slots;

        for (int i = 0; i < _slotUIs.Count; i++)
        {
            if (slots[i].Data != null)
            {
                _slotUIs[i].SetData(slots[i].Data);
            }
            else
            {
                _slotUIs[i].Clear();
            }
        }
    }
    public void SelectItem(InventorySlotUI slot)
    {
        if (slot.Data == null) return;

        if (_selectedSlot == slot)
        {
            ClearSelectedItemWindow();
            return;
        }

        _selectedSlot = slot;
        _selectedItemName.text = _selectedSlot.Data.Name;
        _selectedItemDescription.text = _selectedSlot.Data.Description;
    }
    private void ClearSelectedItemWindow()
    {
        _selectedSlot = null;
        _selectedItemName.text = string.Empty;
        _selectedItemDescription.text = string.Empty;
    }
}
