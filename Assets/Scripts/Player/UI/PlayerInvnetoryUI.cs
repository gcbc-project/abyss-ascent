using System;
using UnityEngine;

public class PlayerInvnetoryUI : MonoBehaviour
{
    [SerializeField] GameObject _uiContainer;
    [SerializeField] GameObject _slotContainer;
    [SerializeField] GameObject _slotPrefab;
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = PlayerManager.Instance.Player.Inventory;
        PlayerManager.Instance.Player.Input.OnInventoryInputEvent += Toggle;
        _playerInventory.OnInventroyChanged += UpdateInventoryUI;
        _uiContainer.SetActive(false);

        for (int i = 0; i < _playerInventory.SlotCount; i++)
        {
            Instantiate(_slotPrefab, _slotContainer.transform);
        }
    }

    private void Toggle()
    {
        _uiContainer.SetActive(!_uiContainer.activeInHierarchy);
    }

    private void UpdateInventoryUI(PlayerInventory inventory)
    {
        throw new NotImplementedException();
    }

}
