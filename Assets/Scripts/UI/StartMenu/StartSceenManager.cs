using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSceenManager : Singleton<StartSceenManager>
{
    [SerializeField] protected PopupDebug popupDebug;
    [SerializeField] protected PopupShowItem popupShowItemBuy;

    protected override void Awake()
    {
        base.Awake();
    }
    [Button]
    public void OpenPopupDebug(string text) { 
        popupDebug.Init(text);
    }

    public void OpenPopupShowItem(Sprite item) {
        popupShowItemBuy.Init(item);
    }

}
