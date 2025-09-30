using UnityEngine;

public class PlayerMove : BaseState<PlayerStateManager>
{
    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.Movement2D.MoveDirection == Vector2.zero)
        {
            player.SwitchState(player.playerIdleState);
        }
    }

    public override void FixedUpdate(PlayerStateManager player)
    {
        player.Movement2D.Move();
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
