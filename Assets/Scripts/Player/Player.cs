using UnityEngine;

public class Player : MonoBehaviour
{

    public StatHandler Stat { get; private set; }
    public PlayerInput Input { get; private set; }
    public PlayerInteraction Interaction { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public Health Health { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerJump Jump { get; private set; }
    public PlayerLook Look { get; private set; }
    public PlayerDash Dash { get; private set; }
    public PlayerClimb Climb { get; private set; }

    [HideInInspector] public bool IsNotGrounded;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        Input = GetComponent<PlayerInput>();
        Interaction = GetComponent<PlayerInteraction>();
        Inventory = GetComponent<PlayerInventory>();
        Stat = GetComponent<StatHandler>();
        Health = GetComponent<Health>();

        Movement = GetComponent<PlayerMovement>();
        Jump = GetComponent<PlayerJump>();
        Look = GetComponent<PlayerLook>();
        Dash = GetComponent<PlayerDash>();
        Climb = GetComponent<PlayerClimb>();
    }
}
