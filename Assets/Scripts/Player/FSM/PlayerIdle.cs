using UnityEngine;

public class PlayerIdle : BaseState<PlayerStateManager>
{
    public override void EnterState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.Movement2D.MoveDirection != Vector2.zero)
        {
            player.SwitchState(player.playerMoveState);
        }
    }

    public override void FixedUpdate(PlayerStateManager player)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

}
