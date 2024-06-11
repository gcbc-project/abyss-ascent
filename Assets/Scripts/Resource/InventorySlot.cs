using UnityEngine;

public class InventorySlot
{
    [HideInInspector] public int Idx;
    [HideInInspector] public ResourceSO Data;
    [HideInInspector] public PlayerInventory Inventory;

    public void Clear()
    {
        Data = null;
    }
}
