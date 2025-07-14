using System;

public abstract class StateManager {
	protected IState stateCurrent;
	public Action<IState> OnExitState;
	public Action<IState> OnEnterState;


	public void ChangeState(IState stateNew) {
		if (stateCurrent == stateNew)
		{
			return;
		}
		else if (stateCurrent == null) {
			stateCurrent = stateNew;
			stateCurrent.Enter();
		}
		else
		{
			stateCurrent.Exit();
			stateCurrent = stateNew;
			stateCurrent.Enter();
		}

	}

	public virtual void Initialize() {
		OnExitState += StateExitHandler;
		OnEnterState += StateEnterHandler;
	}

	public virtual void Update() {
		stateCurrent.UpdateLogic();
	}

	public virtual void FixedUpdate() {
		stateCurrent.UpdatePhysics();
	}

	protected virtual void StateExitHandler(IState state){
	
	}

	protected virtual void StateEnterHandler(IState state) { 
	
	}
}
