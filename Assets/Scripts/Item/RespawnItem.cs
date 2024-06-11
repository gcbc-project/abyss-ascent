using UnityEngine;
using System.Collections;

public class RespawnItem : MonoBehaviour
{
    public StatItem _statItem;
    public float respawnTime = 10f; // �������� �ٽ� ������ �ð�
    private bool isRespawning = false; // �������� ������ ������ ����

    public void RespawnCor()
    {
        StartCoroutine(RespawnCoroutine());
    }

    // ������ ������ �ڷ�ƾ
    public IEnumerator RespawnCoroutine()
    {
            isRespawning = true; 

            yield return new WaitForSeconds(respawnTime);

            transform.GetChild(0).gameObject.SetActive(true);
            isRespawning = false; 
    }
}
