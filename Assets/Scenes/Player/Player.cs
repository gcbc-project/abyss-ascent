using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
    }
}
