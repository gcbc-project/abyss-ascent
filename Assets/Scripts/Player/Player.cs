using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput Input { get; private set; }
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        Input = GetComponent<PlayerInput>();
    }
}
