using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopUp : MonoBehaviour
{
    protected IPopupAnimation popupAnimation;


    protected virtual void Awake()
    {
        CreateAnimationPopup();
    }
    protected abstract void CreateAnimationPopup();

    protected virtual void OnEnable()
    {
        popupAnimation.AnimationEnable();
    }

}
