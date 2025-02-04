using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : Singleton<JoyStick> {
	[SerializeField] private Transform handleJoyStick;
	[SerializeField] private Transform baseJoyStick;
	[SerializeField] private Vector2 direction;
	[SerializeField] private Transform parentCamera;
	private Vector2 positionVecto2 = new Vector2();
	private Vector2 positionInput = new Vector2();
	private bool isJoyStickMove = false;

	public Vector2 Direction {
		get{ 
			return direction;
		}
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			positionInput = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			isJoyStickMove = true;
			ChangeJoyStick ();
			transform.position = positionInput;
			transform.SetParent (parentCamera);
		}
		if(Input.GetMouseButton(0)){
			positionInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			positionVecto2.x = transform.position.x;
			positionVecto2.y = transform.position.y;
			direction = (positionInput - positionVecto2).normalized;
			if (Vector3.Distance (positionInput, positionVecto2) <= 1) {
				handleJoyStick.position = positionInput;
			} else {
				handleJoyStick.position = positionVecto2 + direction;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			isJoyStickMove = false;
			direction = Vector2.zero;
			ChangeJoyStick ();
		}
	}
	
	void ChangeJoyStick(){
		if (isJoyStickMove) {
			baseJoyStick.gameObject.SetActive (true);
			handleJoyStick.gameObject.SetActive (true);
		} else {
			baseJoyStick.gameObject.SetActive (false);
			handleJoyStick.gameObject.SetActive (false);
		}
	}
}
