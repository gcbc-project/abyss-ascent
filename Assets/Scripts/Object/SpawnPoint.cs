using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    LayerMask _playerLayerMask;
    public bool IsNextSet = false;
    private void Start()
    {
        _playerLayerMask = LayerMask.GetMask("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == _playerLayerMask)
        {
            if (!IsNextSet)
            {
                SpwanManager.Instance.SetNextSpawn();
                IsNextSet = true;
            }
        }
    }
}
