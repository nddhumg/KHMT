using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : Singleton<JoyStick> {
	[SerializeField] private Transform handleJoyStick;
	[SerializeField] private Transform baseJoyStick;
	[SerializeField] private Vector2 direction;
	private Vector2 inputStartPosition;
	private bool isJoyStickMove = false;

	public Vector2 Direction {
		get{ 
			return direction;
		}
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			isJoyStickMove = true;
			ChangeJoyStick ();
			inputStartPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = inputStartPosition;
		}
		if(Input.GetMouseButton(0)){
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			direction = (position - inputStartPosition).normalized;
			if (Vector3.Distance (position, inputStartPosition) <= 1) {
				handleJoyStick.position = position;
			} else {
				handleJoyStick.position = inputStartPosition + direction;
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
