using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentBuy : MonoBehaviour
{
    [SerializeField] protected ShopEquipment shopEquipment;
    [SerializeField] protected Button btnBuy;
    [SerializeField] protected Image icon;
    [SerializeField] protected TMP_Text textPrice;
    private uint price = 1000;

    private IItemModel itemData;

    private void Start()
    {
        btnBuy.onClick.AddListener(OnClickBuy);
    }


    public void Create(IItemModel item)
    {
        itemData = item;
        icon.sprite = item.Icon;
        textPrice.text = price.ToString();
    }

    void OnClickBuy()
    {
        if (itemData == null)
            return;
        if (ResourceController.instance.DecreaseResource(EnumName.ResourceName.Coin, price))
        {
            StartSceenManager.instance.OpenPopupShowItem(itemData.Icon);
            shopEquipment.BuyItem(itemData);
        }
        else {
            StartSceenManager.instance.OpenPopupDebug("Khong du tien");
        }
    }
}
