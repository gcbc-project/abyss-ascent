using UnityEngine;

public class StaminaItem : Item
{
    protected override void UseItem(Collider other)
    {
        other.GetComponent<Stamina>().Modify(value);
    }
}
