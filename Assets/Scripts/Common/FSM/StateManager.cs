using UnityEngine;

public class StateManager<TManager> : MonoBehaviour where TManager : StateManager<TManager>
{
    protected BaseState<TManager> currentState;
    // 캐스팅 1회를 위한 self
    private TManager self;

    protected virtual void Awake()
    {
        self = (TManager)this;
    }

    private void Update()
    {
        currentState.UpdateState(self);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate(self);
    }

    public void SwitchState(BaseState<TManager> _state)
    {
        currentState = _state;
        _state.EnterState(self);
    }
}
