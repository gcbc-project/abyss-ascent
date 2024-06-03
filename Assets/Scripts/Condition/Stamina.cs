public class Stamina : BaseCondition
{
    public override ConditionType Type => ConditionType.Stamina;
    public override int Max { get => _stat.CurrentStat.MaxStamina; }
    private float _regenRate = 0.5f;

    protected override void Start()
    {
        base.Start();
        if (_stat.CurrentStat.StaminaRegenAmount != 0)
        {
            InvokeRepeating("RegenStamina", _regenRate, _regenRate);
        }
    }

    private void RegenStamina()
    {
        Modify(_stat.CurrentStat.StaminaRegenAmount);
    }
}