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
    [SerializeField] protected Color hiddenButtonColor;
    [SerializeField] protected Color enabledButtonColor;
    [SerializeField, ReadOnly] protected ShopData data;
    string format = "dd-MM-yyyy";


    protected ResourceName resourceAds;
    protected int valueAds;
    void Awake()
    {
        data = SaveLoadSystem.DataService.Load<ShopData>();
    }
    private void OnApplicationQuit()
    {
        SaveLoadSystem.DataService.Save<ShopData>(ref data);
    }

    private void Start()
    {
        AdsManager.instance.adsShowComplete += this.CompleteAds;

        CheckEnableBtnFree(data.lastFreeCoinClaimDate, btnFreeCoin);
        CheckEnableBtnFree(data.lastFreeCoinVipClaimDate, btnFreeCoinVip);
    }

    public void ClickFreeCoin(int coin)
    {
        ClickGetFree(ResourceName.Coin, coin, btnFreeCoin);
        data.lastFreeCoinClaimDate = DateTime.Now.ToString(format);
    }

    public void ClickFreeCoinVip(int coinVip)
    {
        ClickGetFree(ResourceName.CoinVip, coinVip, btnFreeCoinVip);
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

    protected void ClickGetFree(ResourceName resource, int value, Button btn)
    {
        ResourceController.instance.IncreaseResource(resource, value);
        SetEnableBtnFree(btn, false);
    }

    protected void ClickGetAds(ResourceName resource, int value)
    {
        AdsManager.instance.ShowAdRewaded();
        resourceAds = resource;
        valueAds = value;
    }

    protected void SetEnableBtnFree(Button btn, bool isEnable)
    {
        btn.enabled = isEnable;
        btn.GetComponent<Image>().color = isEnable ? enabledButtonColor : hiddenButtonColor;
    }

    protected void CheckEnableBtnFree(string lastDateData, Button btnFree)
    {
        if (TutorialControl.instance.IsFirstInGame)
            return;
        DateTime lastDate = DateTime.ParseExact(lastDateData, format, CultureInfo.InvariantCulture);

        bool isEnableBtnFreeCoin = (DateTime.Now - lastDate).Days >= 1 ? true : false;
        SetEnableBtnFree(btnFree, isEnableBtnFreeCoin);
    }

}
