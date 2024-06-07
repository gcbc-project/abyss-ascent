using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject _inventory;
    public ResourceSlot[] _slots;
    public Transform _slotPanel;
    public TMP_Text[] _selectedName;
    public TMP_Text _selectedDescription;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = PlayerManager.Instance.Player.Input;
    }

    private void Start()
    {
        _playerInput.Oninventory += Toggle;

        _slots = new ResourceSlot[_slotPanel.childCount];
        _inventory.SetActive(false);

        for(int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = _slotPanel.GetChild(i).GetComponent<ResourceSlot>();
            _slots[i]._index = i;
            _slots[i]._inventory = this;
        }

        ClearSelectedItemInfo();
    }

    private void ClearSelectedItemInfo()
    {
        _selectedDescription.text = string.Empty;
    }

    public void Toggle()
    {
        if(IsOpen())
        {
            _inventory.SetActive(false);
        }
        else
        {
            _inventory.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return _inventory.activeInHierarchy;
    }
}
