using System;
using UnityEngine;

public abstract class BaseCondition : MonoBehaviour, ICondition
{
    protected int _current;
    public int Current { get => _current; }
    public abstract int Max { get; }
    public abstract ConditionType Type { get; }

    public event Action<int, int> OnModifyEvent;

    protected StatHandler _stat;

    protected virtual void Awake()
    {
        _stat = GetComponent<StatHandler>();
    }
    protected virtual void Start()
    {
        _current = Max;
        Modify(0);
    }
    public virtual bool Modify(int amount)
    {
        int prev = _current;
        int calCurrent = _current + amount;

        if (calCurrent > Max || calCurrent < 0) return false;

        _current = calCurrent;

        if (prev != _current)
        {
            OnModifyEvent?.Invoke(_current, Max);
            return true;
        }

        return false;
    }
}
