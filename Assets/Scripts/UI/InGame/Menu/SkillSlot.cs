using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] protected Image icon;

    public void SetIcon(Sprite sprite) {
        gameObject.SetActive(true);
        icon.sprite = sprite;
    }
}
