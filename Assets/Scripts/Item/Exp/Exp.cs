using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour,IItemPickUp {
	[SerializeField] protected uint exp;

	public void PickUp(){
		Player.instance.Level.ExpUp (exp);
		gameObject.SetActive (false);	
	}
}
