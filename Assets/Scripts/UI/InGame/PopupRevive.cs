using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupRevive : PopUp
{
    [SerializeField] protected TMP_Text textTime;
    [SerializeField] protected Button btnAds;
    [SerializeField] protected Button btnRevice;
    [SerializeField] protected TMP_Text textCost;

    [SerializeField] protected uint costRevive;
    [SerializeField] protected uint delayTime = 5;

    [SerializeField] protected Button bnClose;

    public Action OnRevive;
    private void Start()
    {
        btnAds.onClick.AddListener(ReviceAds);
        btnRevice.onClick.AddListener(ReviceCoinVip);
        bnClose.onClick.AddListener(Close);
        textCost.text = $"Revive {costRevive}";
    }

    public void Show() {
        gameObject.SetActive(true);
        StartCoroutine(UpdateTextTimeDelay());
    }


    protected override void CreateAnimationPopup()
    {
        //this.popupAnimation = new 
    }

    protected virtual void ReviceAds()
    {
        AdsManager.instance.ShowAdRewaded();
    }

    protected virtual void ReviceCoinVip()
    {
        if (ResourceController.instance.DecreaseResource(EnumName.ResourceName.CoinVip, costRevive))
        {

        }
    }

    protected IEnumerator UpdateTextTimeDelay()
    {
        while (delayTime > 0)
        {
            textTime.text = delayTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            delayTime--;
        }
        Close();
    }

    protected void Close() { 
        gameObject.SetActive (false);
        ScreenGameOver.instance.ShowUIDeffeat();
    }
}
