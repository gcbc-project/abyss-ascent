using UnityEngine;

public class StaminaItem : Item
{
    public int value;

    protected override void UseItem(Collider other)
    {
        other.GetComponent<Stamina>().Modify(value);
    }

    protected override void EndEffect()
    {

    }
}
