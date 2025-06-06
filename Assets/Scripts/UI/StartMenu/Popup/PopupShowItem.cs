using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupShowItem : PopUp
{
    [SerializeField] protected Image item;
    [SerializeField] protected RectTransform rect;
    [SerializeField] protected Button btnClose;

    private void Start()
    {
        btnClose.onClick.AddListener(Disable);
    }

    public void Init(Sprite sprite) { 
        item.sprite = sprite;
        gameObject.SetActive(true);
    }

    protected override void CreateAnimationPopup()
    {
        this.popupAnimation = new ZoomInAndOutAnimation(this.rect,0.2f,0.2f);
    }

    protected  void Disable()
    {
        popupAnimation.AnimationDisable().onComplete += () => gameObject.SetActive(false);
    }

}
