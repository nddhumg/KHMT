using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour {
	[SerializeField] protected float speed;
	protected Vector3 direction;

	public Vector3 Direction{
		set{ 
			direction = value;
		}
	}

	public float Speed {
		set{ 
			speed = value;
		}
	}


	void Update(){
		transform.parent.position += speed * Time.deltaTime * direction;
	}
}
