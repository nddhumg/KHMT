using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EnumName;

public class ResourceView : MonoBehaviour
{
    [SerializeField] protected TMP_Text textCoin;
    [SerializeField] protected TMP_Text textCoinVip;

    [SerializeField] protected TMP_Text textEnergy;
    [SerializeField] protected Slider sliderEnergy;
    [SerializeField] protected GameObject uiShopEnergy;


    private void Start()
    {
        ResourceController.instance.OnChangeResource += UpdateResouce;
        UpdateResouce();
    }

    public void OnClickEngrgy()
    {
        uiShopEnergy.SetActive(true);
    }

    public void UpdateResouce(ResourceName resourceName)
    {
        int value = ResourceController.instance.GetResource(resourceName);

        if (resourceName == ResourceName.Coin)
            textCoin.text = value.ToString();
        else if (resourceName == ResourceName.CoinVip)
        {
            textCoinVip.text = value.ToString();
        }
        else
        {
            int energyMax = ResourceController.instance.GetResource(ResourceName.EnergyMax);
            textEnergy.text = value.ToString() + "/" + energyMax.ToString();
            float valueSlider = (float)value / energyMax;
            sliderEnergy.value = valueSlider;
        }
    }
    [Button]
    public void UpdateResouce()
    {
        textCoin.text = ResourceController.instance.GetResource(ResourceName.Coin).ToString();

        textCoinVip.text = ResourceController.instance.GetResource(ResourceName.CoinVip).ToString();

        textEnergy.text = ResourceController.instance.GetResource(ResourceName.Energy) + "/" + ResourceController.instance.GetResource(ResourceName.EnergyMax);
        float valueSlider = (float)ResourceController.instance.GetResource(ResourceName.Energy) / ResourceController.instance.GetResource(ResourceName.EnergyMax);
        sliderEnergy.value = valueSlider;
    }

}

