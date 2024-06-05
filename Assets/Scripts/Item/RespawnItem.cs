using UnityEngine;
using System.Collections;

public class RespawnItem : MonoBehaviour
{
    public JumpingItem _statItem;
    public float respawnTime = 10f; // 아이템이 다시 생성될 시간
    private bool isRespawning = false; // 아이템이 리스폰 중인지 여부

    public void RespawnCor()
    {
        StartCoroutine(RespawnCoroutine());
    }

    // 아이템 리스폰 코루틴
    public IEnumerator RespawnCoroutine()
    {
            isRespawning = true; // 아이템 리스폰 중임을 나타냄

            yield return new WaitForSeconds(respawnTime); // 일정 시간을 기다림

            transform.GetChild(0).gameObject.SetActive(true); // 아이템을 다시 활성화하여 생성됨
            isRespawning = false; // 아이템 리스폰 종료
    }
}
