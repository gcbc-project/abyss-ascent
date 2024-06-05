using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private RespawnItem _respawnItem;

    private void Awake()
    { 
        _respawnItem = transform.parent.GetComponent<RespawnItem>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
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
