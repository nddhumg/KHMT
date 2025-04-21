using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBoxChest : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    public void SetIcon(Sprite spriteIcon) {
        icon.sprite = spriteIcon;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
