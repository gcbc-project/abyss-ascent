using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconEffect : MonoBehaviour
{
    public GameObject DurationPrefab;

    public void StartCooldown(float cooldownDuration)
    {
        // 쿨타임 코루틴 시작
        ItemIconEffectItem obj = Instantiate(DurationPrefab, transform).GetComponent<ItemIconEffectItem>();
        obj.StartCooldown(cooldownDuration);
    }
}
