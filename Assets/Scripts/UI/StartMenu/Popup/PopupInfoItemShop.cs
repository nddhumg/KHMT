using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Systems.Inventory;
using TMPro;

public class PopupInfoItemShop : PopUpInfoItem
{
    [SerializeField] protected Button btnBuy;

    [SerializeField] protected TMP_Text textPrice;
    [SerializeField] protected ShopEquipment shopEquipment;

    protected override void Start()
    {
        base.Start();
        btnBuy.onClick.AddListener(Buy);
    }

    public void SetInfo(IItemModel model, uint price) {
        SetInfo(model);
        textPrice.text = price.ToString();
    }


    protected void Buy() {
        shopEquipment.BuyItem(modelItemSelect);
    }
}
