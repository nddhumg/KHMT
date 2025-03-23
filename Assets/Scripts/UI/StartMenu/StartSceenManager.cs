using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceenManager : Singleton<StartSceenManager>
{
    [SerializeField] protected GameObject popupInDevelopment;

    public void OpenPopupInDevelopment() { 
        popupInDevelopment.SetActive(true);
    }
}
