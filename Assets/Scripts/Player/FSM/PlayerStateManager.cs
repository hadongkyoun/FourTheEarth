using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : StateManager<PlayerStateManager>
{
    public PlayerIdle playerIdleState = new PlayerIdle();
    public PlayerMove playerMoveState = new PlayerMove();

    private PlayerMovement2D movement2D;
    public PlayerMovement2D Movement2D { get { return movement2D; } }

    private Vector2          moveInput = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        currentState = playerIdleState;
        currentState.EnterState(this);
        
        movement2D = GetComponent<PlayerMovement2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            movement2D.MoveDirection = moveInput.normalized;
        }
        else if (context.canceled)
        {
            movement2D.MoveDirection = Vector2.zero;
        }
    }

}
