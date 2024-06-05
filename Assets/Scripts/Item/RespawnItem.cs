using UnityEngine;
using System.Collections;

public class RespawnItem : MonoBehaviour
{
    public JumpingItem _statItem;
    public float respawnTime = 10f; // �������� �ٽ� ������ �ð�
    private bool isRespawning = false; // �������� ������ ������ ����

    public void RespawnCor()
    {
        StartCoroutine(RespawnCoroutine());
    }

    // ������ ������ �ڷ�ƾ
    public IEnumerator RespawnCoroutine()
    {
            isRespawning = true; // ������ ������ ������ ��Ÿ��

            yield return new WaitForSeconds(respawnTime); // ���� �ð��� ��ٸ�

            transform.GetChild(0).gameObject.SetActive(true); // �������� �ٽ� Ȱ��ȭ�Ͽ� ������
            isRespawning = false; // ������ ������ ����
    }
}
