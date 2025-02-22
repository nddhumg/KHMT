using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] protected Button btnFreeCoin;
    [SerializeField] protected Image imageBtnFreeCoin;

    [SerializeField] protected Button btnFreeCoinVip;
    [SerializeField] protected Image imageBtnFreeCoinVip;
    [SerializeField] protected Color hiddenButtonColor;


    protected GameSystem.Resource resourceAds;
    protected int valueAds;
    private void Start()
    {
        AdsManager.instance.adsShowComplete += this.CompleteAds;
    }

    public void ClickFreeCoin(int coin) {
        GameSystem.AddCoin(coin);
        btnFreeCoin.enabled = false;
        imageBtnFreeCoin.color = hiddenButtonColor;
        
    }

    public void ClickFreeCoinVip(int coinVip)
    {
        GameSystem.AddCoinVip(coinVip);
        btnFreeCoinVip.enabled = false;
        imageBtnFreeCoinVip.color = hiddenButtonColor;

    }

    public void ClickAdsCoin(int coin) {
        AdsManager.instance.ShowAdRewaded();
        resourceAds = GameSystem.Resource.Coin;
        valueAds = coin;
    }

    public void ClickAdsCoinVip(int coin)
    {
        AdsManager.instance.ShowAdRewaded();
        resourceAds = GameSystem.Resource.CoinVip;
        valueAds = coin;
    }

    protected void CompleteAds() {
        if (resourceAds == GameSystem.Resource.Coin)
        {
            GameSystem.AddCoin(valueAds);
        }
        else if (resourceAds == GameSystem.Resource.CoinVip) {
            GameSystem.AddCoinVip(valueAds);
        }
    }
}
