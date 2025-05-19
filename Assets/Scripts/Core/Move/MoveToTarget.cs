using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
	[SerializeField] protected float speed =10f;
	[SerializeField] protected Transform target;
	[SerializeField] protected bool isFollowing;

	void LateUpdate() {
		if (isFollowing == false)
			return;
		transform.parent.position = Vector2.Lerp (transform.parent.position, target.position, speed * Time.deltaTime);		
	}
}
