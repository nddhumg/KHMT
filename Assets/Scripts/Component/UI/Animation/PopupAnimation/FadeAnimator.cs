using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimator : IPopupAnimation
{
    protected CanvasGroup canvasGroup;
    protected float fadeInDuration;
    protected float fadeOutDuration;

    public FadeAnimator(CanvasGroup canvasGroup, float fadeInDuration = 1, float fadeOutDuration = 1)
    {
        this.canvasGroup = canvasGroup;
        this.fadeInDuration = fadeInDuration;
        this.fadeOutDuration = fadeOutDuration;
    }

    public Tween AnimationDisable()
    {
        return canvasGroup.DOFade(0, fadeOutDuration);
    }

    public Tween AnimationEnable()
    {
        canvasGroup.alpha = 0;
        return canvasGroup.DOFade(1, fadeInDuration);
    }
}
