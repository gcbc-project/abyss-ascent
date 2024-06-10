using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action<PlayerInventory> OnInventroyChanged;

    public InventorySlot[] Slots { get; private set; }
    public int SlotCount { get; private set; } = 3;
    ResourceSO _resourceData;

    private void Start()
    {
        PlayerManager.Instance.Player.Input.OnAddResource += AddItem;

        Slots = new InventorySlot[SlotCount];

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].Idx = i;
            Slots[i].Inventory = this;
            Slots[i].Clear();
            OnInventroyChanged?.Invoke(this);
        }
    }

    private void AddItem(ResourceSO data)
    {
        if (_resourceData == null) return;

        InventorySlot emptySlot = GetemptySlot();

        if (emptySlot != null)
        {
            emptySlot.Data = data;
            OnInventroyChanged?.Invoke(this);
        }
    }

    private InventorySlot GetemptySlot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].Data == null)
            {
                return Slots[i];
            }
        }
        return null;
    }

}