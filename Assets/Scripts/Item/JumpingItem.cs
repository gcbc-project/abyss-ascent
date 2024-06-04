using UnityEngine;

public class JumpingItem : Item
{
    [SerializeField] private StatSO _stat;
    private StatHandler _handler;
    public ItemIconEffect _effect;

    protected override void UseItem(Collider other)
    {
        _handler = other.GetComponent<StatHandler>();
        _handler.AddStat(_stat);
        _handler.UpdateStat();
        Invoke("EndEffect", 3f);
        _effect.SetBlink(3f);
    }

    protected override void EndEffect()
    {
        _handler.SubStat(_stat);
        _handler.UpdateStat();
        
    }
}