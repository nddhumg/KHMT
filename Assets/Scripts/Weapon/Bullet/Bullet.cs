using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] protected SOStat stat;

	void OnValidate(){
		ISetStat[] setState = gameObject.GetComponentsInChildren<ISetStat> ();
		foreach (ISetStat obj in setState) {
			obj.SetStat (stat);
		}
	}
}
