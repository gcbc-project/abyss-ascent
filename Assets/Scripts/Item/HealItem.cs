using UnityEngine;

public class HealItem : Item
{
    public int value;

    protected override void UseItem(Collider other)
    {
        other.GetComponent<Health>().Modify(value);
    }

    protected override void EndEffect()
    {

    }
}
