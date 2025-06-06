using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ndd.Cooldown;
using DG.Tweening;

public class PopupDebug : PopUp
{
    [SerializeField] protected CanvasGroup group;
    [SerializeField] protected TMP_Text textDebug;
    [SerializeField] protected float duration = 2f;

    protected ICoolDownAuto coolDownAuto;

    private void Start()
    {
        coolDownAuto = new AutoCooldownTimer(duration, action: ExitPopup);
    }

    private void Update()
    {
        coolDownAuto.UpdateCooldown(Time.deltaTime);
    }

    public void Init(string text)
    {
        textDebug.text = text;
        gameObject.SetActive(true);
    }

    protected override void CreateAnimationPopup()
    {
        popupAnimation = new FadeAnimator(group, 0.5f, 0.5f);
    }

    protected void ExitPopup()
    {
        popupAnimation.AnimationDisable().OnComplete(() => gameObject.SetActive(false));
    }


}
