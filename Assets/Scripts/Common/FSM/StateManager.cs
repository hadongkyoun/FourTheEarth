using UnityEngine;

public class StateManager<TManager> : MonoBehaviour where TManager : StateManager<TManager>
{
    protected BaseState<TManager> currentState;
    // ĳ���� 1ȸ�� ���� self
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
