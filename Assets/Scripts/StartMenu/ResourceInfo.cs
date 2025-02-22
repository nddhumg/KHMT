using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UIStart
{
    public class ResourceInfo : MonoBehaviour
    {
        [SerializeField] protected TMP_Text textCoin;
        [SerializeField] protected TMP_Text textCoinVip;

        [SerializeField] protected TMP_Text textEnergy;
        [SerializeField] protected Slider sliderEnergy;
        [SerializeField] protected GameObject uiShopEnergy;

        private void Start()
        {
            GameSystem.onChangeResource += SetResource;
            SetResource(GameSystem.Resource.Coin);
            SetResource(GameSystem.Resource.Energy);
            SetResource(GameSystem.Resource.CoinVip);
        }

        public void OnClickEngrgy() { 
            uiShopEnergy.SetActive(true);
        }

        public void SetResource(GameSystem.Resource resource) {
            if (resource == GameSystem.Resource.Coin)
                textCoin.text = GameSystem.Coin.ToString();
            else if (resource == GameSystem.Resource.CoinVip)
            {
                textCoinVip.text = GameSystem.CoinVip.ToString();
            }
            else {
                textEnergy.text = GameSystem.Energy.ToString() + "/" + GameSystem.EnergyMax;
                float valueSlider = GameSystem.Energy / GameSystem.EnergyMax;
                sliderEnergy.value = valueSlider;
            }
        }
    }
}
