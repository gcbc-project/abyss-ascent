using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private RespawnItem _respawnItem;

    private void Update()
    {
        //Space World를 추가함으로써 월드 좌표로 y축을 기준으로 돈다를 표현
        transform.Rotate(Vector3.up * 100 * Time.deltaTime, Space.World);
    }

    private void Awake()
    { 
        _respawnItem = transform.parent.GetComponent<RespawnItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UseItem(other);
            _respawnItem.RespawnCor();
            gameObject.SetActive(false);
        }
    }

    protected abstract void UseItem(Collider other);

    protected abstract void EndEffect();

}
