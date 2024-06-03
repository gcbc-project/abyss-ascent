using System;

public class Health : BaseCondition
{
    public override ConditionType Type => ConditionType.Health;
    public override int Max { get => _stat.CurrentStat.MaxHP; }
    public event Action<int> OnDamageEvent;
    public event Action<int> OnHealEvent;
    public event Action OnDeathEvent;

    public override bool Modify(int amount)
    {
        if (!base.Modify(amount)) return false;

        if (Current == 0)
        {
            OnDeathEvent?.Invoke();
        }

        if (amount < 0)
        {
            OnDamageEvent?.Invoke(amount);
        }
        else
        {
            OnHealEvent?.Invoke(amount);
        }

        return true;
    }
}