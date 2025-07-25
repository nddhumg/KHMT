using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour {
	[SerializeField] protected Image icon;
	[SerializeField] protected TMP_Text text;
	[SerializeField] protected Button btnSelect;

	private int indexSelect;

    private void Start()
    {
		btnSelect.onClick.AddListener(Select);
    }

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
