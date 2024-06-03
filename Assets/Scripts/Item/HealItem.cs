using UnityEngine;

public class HealItem : Item
{
    protected override void UseItem(Collider other)
    {
        other.GetComponent<Health>().Modify(value);
    }
}
