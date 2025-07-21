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
    //[SerializeField] protected Image iconResourcePrice;

    private IItemModel modelItem;

    private void Start()
    {
        btnBuy.onClick.AddListener(OnClickBuy);
    }


    public void Create(IItemModel item, uint price)
    {
        modelItem = item;
        icon.sprite = item.Icon;
        textPrice.text = price.ToString();
    }

    void OnClickBuy()
    {
        if (modelItem == null)
            return;
        shopEquipment.OpenPopUpInfo(modelItem);
    }
}
