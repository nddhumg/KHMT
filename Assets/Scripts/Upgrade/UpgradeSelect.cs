using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour {
	[SerializeField] protected Image icon;
	[SerializeField] protected Text text;

	private int indexSelect;

	public void SetInfo(int index, Sprite icon, string text)
	{
		this.indexSelect = index;
		this.icon.sprite = icon;
		this.text.text = text;
	}

	public void Select()
	{
		UpgradeSystem.instance.ApllyUpgrade(indexSelect);
	}
}
