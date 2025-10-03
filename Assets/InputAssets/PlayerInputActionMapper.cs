using UnityEngine;

public class PlayerInputActionMapper : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    public PlayerInputActions PlayerInputActions { get { return playerInputActions; } }

    public bool inputActionsEnabled = false;

    // Interact, Quest
    PlayerNumber playerNumber;
    PlayerStateManager playerStateManager;

    private void Awake()
    {
        playerNumber = GetComponent<PlayerNumber>();
        playerStateManager = GetComponent<PlayerStateManager>();

        playerInputActions = new PlayerInputActions();
    }
}
