using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	//protected CooldownTimer timer ;
	protected ICoolDownAuto timer;
	[SerializeField] protected float destroyTime = 3f;

	protected virtual void Awake() {
		timer = new AutoCooldownTimer(destroyTime);
		timer.AddTimeoutListener(DestroyObject);
	}

	protected virtual void Update() {
		timer.UpdateCooldown(Time.deltaTime);
	}
	protected virtual void DestroyObject()
	{
		Destroy (transform.parent);
	}
}
