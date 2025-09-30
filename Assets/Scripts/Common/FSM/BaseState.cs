

using UnityEngine;

public abstract class BaseState<TManager> where TManager : StateManager<TManager>
{
    // Target Manager
    public abstract void EnterState(TManager tManager);

    public abstract void UpdateState(TManager tManager);

    public abstract void FixedUpdate(TManager tManager);

    public abstract void ExitState(TManager tManager);

}
