using UnityEngine.UI;
using UnityEngine;
using EnumName;
using Systems.SaveLoad;
using System;
using System.Globalization;

public class ShopResource : MonoBehaviour
{
    [SerializeField] protected Button packageFreeCoin;
    [SerializeField] protected Button packageFreeCoinVip;
    [SerializeField] protected Image bgBtnFreeCoin;
    [SerializeField] protected Image bgBtnFreeCoinVip;
    [SerializeField] protected Color hiddenButtonColor;
    [SerializeField] protected Color enabledButtonColor;

    [SerializeField] protected ShopManager shopManager;


    protected ResourceName resourceAds;
    protected int valueAds;

    private void Start()
    {
        AdsManager.instance.adsShowComplete += this.CompleteAds;
        CheckEnablePackageFree(shopManager.Data.lastFreeCoinClaimDate, packageFreeCoin,bgBtnFreeCoin);
        CheckEnablePackageFree(shopManager.Data.lastFreeCoinVipClaimDate, packageFreeCoinVip, bgBtnFreeCoinVip);
    }

    public void ClickFreeCoin(int coin)
    {
        ClickGetFree(ResourceName.Coin, coin, packageFreeCoin,bgBtnFreeCoin);
        shopManager.Data.lastFreeCoinClaimDate = DateTime.Now.ToString(shopManager.FormatTime);
    }

    public void ClickFreeCoinVip(int coinVip)
    {
        ClickGetFree(ResourceName.CoinVip, coinVip, packageFreeCoinVip, bgBtnFreeCoinVip);
        shopManager.Data.lastFreeCoinVipClaimDate = DateTime.Now.ToString(shopManager.FormatTime);
    }

    public void ClickAdsCoin(int coin)
    {
        ClickGetAds(ResourceName.Coin, coin);
    }

    public void ClickAdsCoinVip(int coinVip)
    {
        ClickGetAds(ResourceName.CoinVip, coinVip);
    }

    protected void CompleteAds()
    {
        ResourceController.instance.IncreaseResource(resourceAds, valueAds);
    }

    protected void ClickGetFree(ResourceName resource, int value, Button btn,Image bg)
    {
        ResourceController.instance.IncreaseResource(resource, value);
        SetEnableBtnFree(btn, false,bg);
    }

    protected void ClickGetAds(ResourceName resource, int value)
    {
        AdsManager.instance.ShowAdRewaded();
        resourceAds = resource;
        valueAds = value;
    }

    protected void SetEnableBtnFree(Button btn, bool isEnable,Image bg)
    {
        btn.enabled = isEnable;
        bg.color = isEnable ? enabledButtonColor : hiddenButtonColor;
    }

    protected void CheckEnablePackageFree(string lastDateData, Button btnFree,Image imgBg)
    {
        try
        {
            DateTime lastDate = DateTime.ParseExact(lastDateData, shopManager.FormatTime, CultureInfo.InvariantCulture);

            bool isEnableBtnFreeCoin = (DateTime.Now - lastDate).Days >= 1 ? true : false;

            SetEnableBtnFree(btnFree, isEnableBtnFreeCoin, imgBg);
        }
        catch {
            SetEnableBtnFree(btnFree, true, imgBg);
        }
    }

}
