using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] protected SOStat stat;

	protected virtual void Start ()
	{
		ISetStat[] setState = gameObject.GetComponentsInChildren<ISetStat> ();
		Debug.Log (setState.Length);
		foreach (ISetStat obj in setState) {
			obj.SetStat (stat);
		}
	}
}
