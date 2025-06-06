using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSceenManager : Singleton<StartSceenManager>
{
    [SerializeField] protected GameObject popupInDevelopment;
    [SerializeField] protected PopupDebug popupDebug;
    [SerializeField] protected PopupShowItem popupShowItemBuy;

    [Button]
    public void OpenPopupDebug(string text) { 
        popupDebug.Init(text);
    }

    public void OpenPopupShowItem(Sprite item) {
        popupShowItemBuy.Init(item);
    }

    public void OpenPopupInDevelopment() { 
        popupInDevelopment.SetActive(true);
    }
}
