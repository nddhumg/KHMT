public class StateManager  {
	protected IState stateCurrent;

	public void ChangeState(IState stateNew){
		if (stateCurrent == stateNew || stateCurrent == null) {
			return;
		}
		stateCurrent.Exit ();
		stateCurrent = stateNew;
		stateCurrent.Enter ();
	}

	public virtual void Initialize(){
		
	}

	public virtual void Update(){
		stateCurrent.UpdateLogic ();
	}

	public virtual void FixedUpdate(){
		stateCurrent.UpdatePhysics ();
	}
}
