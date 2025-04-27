using UnityEngine.UI;
using UnityEngine;
using EnumName;
using Systems.SaveLoad;
using System;
using System.Globalization;

public class ShopManager : MonoBehaviour
{
    [SerializeField] protected Button btnFreeCoin;
    [SerializeField] protected Button btnFreeCoinVip;
    [SerializeField] protected Image bgBtnFreeCoin;
    [SerializeField] protected Image bgBtnFreeCoinVip;
    [SerializeField] protected Color hiddenButtonColor;
    [SerializeField] protected Color enabledButtonColor;
    [SerializeField, ReadOnly] protected ShopData data = new();
    string format = "dd-MM-yyyy";


    protected ResourceName resourceAds;
    protected int valueAds;
    private void OnApplicationQuit()
    {
        SaveLoadSystem.DataService.Save<ShopData>(ref data);
    }

    private void Start()
    {
        data = SaveLoadSystem.DataService.Load<ShopData>(gameObject) ?? data;
        AdsManager.instance.adsShowComplete += this.CompleteAds;
        CheckEnableBtnFree(data.lastFreeCoinClaimDate, btnFreeCoin,bgBtnFreeCoin);
        CheckEnableBtnFree(data.lastFreeCoinVipClaimDate, btnFreeCoinVip, bgBtnFreeCoinVip);
    }

    public void ClickFreeCoin(int coin)
    {
        ClickGetFree(ResourceName.Coin, coin, btnFreeCoin,bgBtnFreeCoin);
        data.lastFreeCoinClaimDate = DateTime.Now.ToString(format);
    }

    public void ClickFreeCoinVip(int coinVip)
    {
        ClickGetFree(ResourceName.CoinVip, coinVip, btnFreeCoinVip, bgBtnFreeCoinVip);
        data.lastFreeCoinVipClaimDate = DateTime.Now.ToString(format);
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

    protected void CheckEnableBtnFree(string lastDateData, Button btnFree,Image imgBg)
    {
        try
        {
            DateTime lastDate = DateTime.ParseExact(lastDateData, format, CultureInfo.InvariantCulture);

            bool isEnableBtnFreeCoin = (DateTime.Now - lastDate).Days >= 1 ? true : false;

            SetEnableBtnFree(btnFree, isEnableBtnFreeCoin, imgBg);
        }
        catch {
            SetEnableBtnFree(btnFree, true, imgBg);
        }
    }

}
