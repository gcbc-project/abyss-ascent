using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconEffectItem : MonoBehaviour
{
    private Image cooldownImage;

    private void Awake()
    {
        // Image 컴포넌트 가져오기
        cooldownImage = GetComponent<Image>();
        // 초기 fillAmount를 1로 설정하여 쿨타임이 끝난 상태로 설정
        cooldownImage.fillAmount = 1f;
    }

    public void StartCooldown(float cooldownDuration)
    {
        // 쿨타임 코루틴 시작
        StartCoroutine(CooldownRoutine(cooldownDuration));
    }

    private IEnumerator CooldownRoutine(float duration)
    {
        float elapsedTime = 0f;

        // 쿨타임이 진행되는 동안 fillAmount를 업데이트
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cooldownImage.fillAmount = 1f - (elapsedTime / duration);
            yield return null;
        }

        // 쿨타임이 끝나면 fillAmount를 1로 설정
        cooldownImage.fillAmount = 1f;
        Destroy(gameObject);
    }
}
