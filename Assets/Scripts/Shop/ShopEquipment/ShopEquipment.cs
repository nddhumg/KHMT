using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class ShopEquipment : MonoBehaviour
{
    [SerializeField] protected EquipmentBuy[] equipmentsBuy;
    [SerializeField] protected Button btnBuyRandom;
    [SerializeField] protected PopupInfoItemShop popupInfo;
    [SerializeField] protected EquipmentPriceContainer equipmentPriceContainer;

    [SerializeField] protected uint priceRandom = 1000;
    protected EnumName.ResourceName resourceBuyRandom = EnumName.ResourceName.Coin;
    //[SerializeField] protected EquipmentPrice[] equipmentPricesBuy;
    void Start()
    {
        //equipmentPricesBuy = new EquipmentPrice[equipmentsBuy.Length];
        CreateRandomEquipmentsBuy();
        btnBuyRandom.onClick.AddListener(BuyRandom);
    }
    public void BuyItem(IItemModel itemModel)
    {
        popupInfo.gameObject.SetActive(false);
        EquipmentPrice equipment = equipmentPriceContainer.GetEquipmentPrice(itemModel.Type);
        if (ResourceController.instance.DecreaseResource(equipment.resource, equipment.price))
        {
            InventoryManager.instance.AddItem(itemModel);
            StartSceenManager.instance.OpenPopupShowItem(itemModel.Icon);
        }
        else
        {
            StartSceenManager.instance.OpenPopupDebug(GameMessages.GetMesage(MessageKey.NotEnoughGold));
        }
    }

    public void OpenPopUpInfo(IItemModel itemModel)
    {
        popupInfo.gameObject.SetActive(true);
        popupInfo.SetInfo(itemModel, equipmentPriceContainer.GetEquipmentPrice(itemModel.Type).price);
    }

    void CreateRandomEquipmentsBuy()
    {
        List<IItemModel> models = InventoryManager.instance.ItemModelContainer.GetRandomModels(equipmentsBuy.Length);
        for (int i = 0; i < models.Count; i++)
        {
            //equipmentPricesBuy[i] = equipmentPriceContainer.GetEquipmentPrice(models[i].Type);
            equipmentsBuy[i].Create(models[i], equipmentPriceContainer.GetEquipmentPrice(models[i].Type).price);
        }
    }

    void BuyRandom()
    {
        if (ResourceController.instance.DecreaseResource(resourceBuyRandom, priceRandom))
        {
            IItemModel model = InventoryManager.instance.ItemModelContainer.GetRandomModel();
            StartSceenManager.instance.OpenPopupShowItem(model.Icon);
            InventoryManager.instance.AddItem(model);   
        }
        else
        {
            StartSceenManager.instance.OpenPopupDebug(GameMessages.GetMesage(MessageKey.NotEnoughGold));
        }
    }

}
