using UnityEngine;

public class JumpingItem : Item
{
    [SerializeField] private StatSO _stat;
    private StatHandler _handler;

    protected override void UseItem(Collider other)
    {
        _handler = other.GetComponent<StatHandler>();
        _handler.AddStat(_stat);
        _handler.UpdateStat();
        Invoke("EndEffect", 3f);
    }

    protected override void EndEffect()
    {
        _handler.SubStat(_stat);
        _handler.UpdateStat();
        
    }
}