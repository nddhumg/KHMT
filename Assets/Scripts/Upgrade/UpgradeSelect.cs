using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour {
	[SerializeField] protected Image icon;
	[SerializeField] protected Text text;

	private uint index = 0;

	public void SetInfo(uint index, Sprite icon, string text)
	{
		this.index = index;
		this.icon.sprite = icon;
		this.text.text = text;
	}

	public void Select()
	{
		//UpgradeSystem.instance.ApllyUpgrade(index);
	}
}
