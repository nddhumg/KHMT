public class StateManager  {
	protected IState stateCurrent;

	public void ChangeState(IState stateNew){
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
            stateCurrent.Exit ();
			stateCurrent = stateNew;
			stateCurrent.Enter ();
        }
        
	}

	public virtual void ResetState(){

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
