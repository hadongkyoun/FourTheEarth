using UnityEngine;

public class EnemyStateManager : StateManager<EnemyStateManager>
{
    EnemyIdle enemyIdleState = new EnemyIdle();

    protected override void Awake()
    {
        base.Awake();
        currentState = enemyIdleState;
        currentState.EnterState(this);

    }
}
