using UnityEngine;

public class Player : MonoBehaviour
{
    public StatHandler Stat { get; private set; }
    public PlayerInput Input { get; private set; }
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        Input = GetComponent<PlayerInput>();
        Stat = GetComponent<StatHandler>();
    }
}
