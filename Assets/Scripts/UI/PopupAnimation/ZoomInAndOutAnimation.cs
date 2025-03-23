using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZoomInAndOutAnimation : IPopupAnimation
{
    private RectTransform popup;
    private Vector3 scaleBase = new Vector3();
    private float durationZoomIn;
    private float durationZoomOut;
    public ZoomInAndOutAnimation(RectTransform popup, float durationZoomIn = 1, float durationZoomOut = 1)
    {
        this.popup = popup;
        scaleBase = popup.localScale;
        this.durationZoomIn = durationZoomIn;
        this.durationZoomOut = durationZoomOut;
    }
    public Tween AnimationDisable()
    {
        return popup.DOScale(Vector3.zero, durationZoomIn);
    }

    public Tween AnimationEnable()
    {
        popup.localScale = Vector3.zero;
        return popup.DOScale(scaleBase,durationZoomIn);
    }
}
