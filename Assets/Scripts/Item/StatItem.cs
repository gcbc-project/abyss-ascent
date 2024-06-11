using UnityEngine;

public class StatItem : Item
{
    [SerializeField] private StatSO _stat;
    private StatHandler _handler;
    public ItemIconEffect _effect;
    public float duration = 3f;

    protected override void UseItem(Collider other)
    {
        _handler = other.GetComponent<StatHandler>();
        _handler.AddStat(_stat);
        _handler.UpdateStat();
        Invoke("EndEffect", duration);
        _effect.StartCooldown(duration);
    }

    protected override void EndEffect()
    {
        _handler.SubStat(_stat);
        _handler.UpdateStat();
    }
}