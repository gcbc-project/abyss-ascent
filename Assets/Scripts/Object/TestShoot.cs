using UnityEngine;

public class TestShoot : MonoBehaviour
{
    public static TestShoot Instance;
    public Transform Player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject obj = ObjectPoolManager.Instance.SpawnPool("ProjectileObj", transform.position);
        ProjectileObject pro = obj.GetComponent<ProjectileObject>();
        if (pro != null)
        {
            pro.SetDirection(Player.position - transform.position);
        }

    }
}
