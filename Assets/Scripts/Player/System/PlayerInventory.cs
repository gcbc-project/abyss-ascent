using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action OnInventoryChanged;

    public InventorySlot[] Slots { get; set; }
    public int SlotCount { get; private set; } = 3;

    private void Start()
    {
        PlayerManager.Instance.Player.Input.OnAddResource += AddItem;
    }

    public void InitializeSlots()
    {
        Slots = new InventorySlot[SlotCount];

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i] = new InventorySlot();
            Slots[i].Idx = i;
            Slots[i].Inventory = this;
            Slots[i].Clear();
        }
    }

    private void AddItem(ResourceSO data)
    {
        if (data == null) return;

        InventorySlot emptySlot = GetemptySlot();

        if (emptySlot != null)
        {
            emptySlot.Data = data;
            OnInventoryChanged?.Invoke();
        }
    }

    public void RemoveItem(ResourceSO data)
    {
        if (data == null) return;

        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].Data == data)
            {
                Slots[i].Clear();
                OnInventoryChanged?.Invoke();
                return;
            }
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