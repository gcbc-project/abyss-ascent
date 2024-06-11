using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] MoveDir dir;  // 문이 이동할 방향
    [SerializeField] string _keyId;  // 문을 열기 위한 키 ID
    [SerializeField] float moveDistance = 5f;  // 문이 이동할 거리
    [SerializeField] float moveDuration = 1f;  // 문이 이동하는 시간

    public string GetInteractPrompt()
    {
        return "문 열기";
    }

    public void OnInteract()
    {
        foreach (InventorySlot slot in PlayerManager.Instance.Player.Inventory.Slots)
        {
            // 슬롯에 데이터가 있고 데이터가 ResourceKeySO인지 확인
            if (slot.Data != null && slot.Data is ResourceKeySO keyData)
            {
                if (_keyId == keyData.KeyId)
                {
                    slot.Inventory.RemoveItem(keyData);
                    Open();
                    return; // 문이 열리면 더 이상 반복하지 않음
                }
            }
        }
    }

    public void Open()
    {
        MoveDirection(dir); // 문을 열 때 지정된 방향으로 이동
    }

    void MoveDirection(MoveDir dir)
    {
        Vector3 moveVector = Vector3.zero;

        switch (dir)
        {
            case MoveDir.MoveToX:
                moveVector = Vector3.right;
                break;
            case MoveDir.MoveToY:
                moveVector = Vector3.up;
                break;
            case MoveDir.MoveToZ:
                moveVector = Vector3.forward;
                break;
        }

        // 목표 위치 계산
        Vector3 targetPosition = transform.position + moveVector * moveDistance;

        // 문을 지정된 방향으로 이동
        StartCoroutine(MoveToPosition(targetPosition, moveDuration));
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 이동 완료
        transform.position = targetPosition;
    }
}
