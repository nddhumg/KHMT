using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour,IItemPickUp {
	[SerializeField] protected uint exp;
	[SerializeField] protected SOExp dataExp;

    private void OnValidate()
    {
        if(dataExp != null) 
            exp = dataExp.ExpValue;
    }

    public void PickUp(){
		Player.instance.Level.ExpUp (exp);
		gameObject.SetActive (false);	
	}
}
