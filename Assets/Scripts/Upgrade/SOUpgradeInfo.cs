using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "SO/Upgrade/Info")]
public class SOUpgradeInfo : ScriptableObject {
	[SerializeField] protected Sprite icone;
	[SerializeField] protected string text;

	public Sprite Icone {
		get { 
			return icone;
		}
	}
	public string Text{
		get{ 
			return text;
		}
	}
}
