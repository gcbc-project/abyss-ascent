using UnityEngine;
using System.Collections;

public class RespawnItem : MonoBehaviour
{
    public StatItem _statItem;
    public float respawnTime = 10f; // 아이템이 다시 생성될 시간
    private bool isRespawning = false; // 아이템이 리스폰 중인지 여부

    public void RespawnCor()
    {
        StartCoroutine(RespawnCoroutine());
    }

    // 아이템 리스폰 코루틴
    public IEnumerator RespawnCoroutine()
    {
            isRespawning = true; 

            yield return new WaitForSeconds(respawnTime);

            transform.GetChild(0).gameObject.SetActive(true);
            isRespawning = false; 
    }
}
