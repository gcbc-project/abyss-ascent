using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void Start()
    {
        PlayerManager.Instance.Player.Health.OnDeathEvent += OnDeath;
    }

    private void OnDeath()
    {
        StartCoroutine(DelayedSpawnCoroutine());
    }
    private IEnumerator DelayedSpawnCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        SpwanManager.Instance.Spawn();
    }
}
