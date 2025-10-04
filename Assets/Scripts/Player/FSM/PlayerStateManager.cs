using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : StateManager<PlayerStateManager>
{
    public PlayerIdle playerIdleState = new PlayerIdle();
    public PlayerMove playerMoveState = new PlayerMove();

    private PlayerMovement2D movement2D;
    public PlayerMovement2D Movement2D { get { return movement2D; } }

    private Vector2 moveInput = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        currentState = playerIdleState;
        currentState.EnterState(this);

        movement2D = GetComponent<PlayerMovement2D>();
        
    }
    private void Start()
    {
        if (TryGetComponent<PlayerInputActionMapper>(out PlayerInputActionMapper _playerActionMapper))
        {
            PlayerInputActions playerInputActions = _playerActionMapper.PlayerInputActions;
            playerInputActions.Player.Move.performed += Move;
            playerInputActions.Player.Move.canceled += Stop;
        }
    }

    private void OnDestroy()
    {
        if (TryGetComponent<PlayerInputActionMapper>(out PlayerInputActionMapper _playerActionMapper))
        {
            PlayerInputActions playerInputActions = _playerActionMapper.PlayerInputActions;
            playerInputActions.Player.Move.performed -= Move;
            playerInputActions.Player.Move.canceled -= Stop;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        movement2D.MoveDirection = moveInput.normalized;

    }

    public void Stop(InputAction.CallbackContext context)
    {
        movement2D.MoveDirection = Vector2.zero;
    }

}
