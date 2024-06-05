using UnityEngine;

public class Player : MonoBehaviour
{

    public StatHandler Stat { get; private set; }
    public PlayerInput Input { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerJump Jump { get; private set; }
    public PlayerLook Look { get; private set; }
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        Input = GetComponent<PlayerInput>();
        Stat = GetComponent<StatHandler>();

        Movement = GetComponent<PlayerMovement>();
        Jump = GetComponent<PlayerJump>();
        Look = GetComponent<PlayerLook>();
    }
}
