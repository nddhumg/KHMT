public interface IState {
	void Enter ();
	void Exit();
	void UpdateLogic ();
	void UpdatePhysics ();
}
