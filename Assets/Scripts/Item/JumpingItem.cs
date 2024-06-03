using UnityEngine;

public class JumpingItem : Item
{
    protected override void UseItem(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * value, ForceMode.Impulse);
    }
}