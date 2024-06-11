using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsNextSet = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!IsNextSet)
        {
            SpwanManager.Instance.SetNextSpawn();
            IsNextSet = true;
        }
    }
}
