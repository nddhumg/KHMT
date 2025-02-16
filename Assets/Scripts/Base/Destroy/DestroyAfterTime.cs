using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	protected CoolDownTimer timer ;
	[SerializeField] protected float destroyTime = 3f;

	protected virtual void Awake() {
		timer = new CoolDownTimer(destroyTime);
		timer.OnCoolDownEnd += DestroyObject;
	}
	protected virtual void DestroyObject()
	{
		Destroy (transform.parent);
	}
}
