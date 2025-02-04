using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectHandler : NddBehaviour {
	[SerializeField] protected float timer;
	[SerializeField] protected float actionDelay;

	protected virtual void Update(){
		timer += Time.deltaTime;
		if(CanExecute()){
			timer = 0f;
			HandleObject();
		}
	}

	protected virtual bool CanExecute(){
		if (timer >= actionDelay)
			return true;
		return false;
	}
	protected abstract void HandleObject ();
}
