using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] private StatSO _baseStat;
    [HideInInspector] public StatSO CurrentStat;
    private List<StatSO> _stats = new List<StatSO>();

    private void Awake()
    {
        UpdateStat();
    }

    public void AddStat(StatSO stat)
    {
        _stats.Add(stat);
    }

    public void UpdateStat()
    {
        CurrentStat = _baseStat.DeepCopy();

        _stats = _stats.OrderBy(stat => stat.Type).ToList();
        for (int i = 0; i < _stats.Count; i++)
        {
            switch (_stats[i].Type)
            {
                case StatType.Add:
                    CurrentStat.Add(_stats[i]);
                    break;
                case StatType.Multiple:
                    CurrentStat.Multiply(_stats[i]);
                    break;
                case StatType.Override:
                    CurrentStat = _stats[i].DeepCopy();
                    break;
            }
        }
    }
}