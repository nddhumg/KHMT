using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	[SerializeField] protected float timer = 0f;
	[SerializeField] protected float destroyTime = 3f;

	protected virtual void Update(){
		timer += Time.deltaTime;
		if(timer >= destroyTime){
			timer = 0f;
			DestroyObject ();
		}
	}

	protected virtual void DestroyObject()
	{
		Destroy (transform.parent);
	}
}
