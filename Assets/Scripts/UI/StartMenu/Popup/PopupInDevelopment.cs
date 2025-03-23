using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupInDevelopment : PopUp
{
    [SerializeField] protected RectTransform rect;
    [SerializeField] protected Button btnExit;
    [SerializeField] private float dureationZoom;

    void Start()
    {
        btnExit.onClick.AddListener(OnClickExit);
    }
    protected override void CreateAnimationPopup()
    {
        popupAnimation = new ZoomInAndOutAnimation(rect,durationZoomIn: dureationZoom, durationZoomOut: dureationZoom);
    }

    void OnClickExit() {
        popupAnimation.AnimationDisable()
            .OnComplete(() => gameObject.SetActive(false)) ;
    }

}
