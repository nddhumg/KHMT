using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class ShopEquipment : MonoBehaviour
{
    [SerializeField] protected EquipmentBuy[] equipmentsBuy;
    [SerializeField] protected Button btnBuyRandom;
    [SerializeField] protected uint priceRandom = 1000;
     protected EnumName.ResourceName resourceBuyRandom = EnumName.ResourceName.Coin;
    void Start()
    {
        CreateRandomEquipmentsBuy();
        btnBuyRandom.onClick.AddListener(BuyRandom);
    }
    public void BuyItem(IItemModel itemModel)
    {
        InventoryManager.instance.AddItem(itemModel);
    }

    void CreateRandomEquipmentsBuy()
    {
        List<IItemModel> models = InventoryManager.instance.ItemModelContainer.GetRandomModels(equipmentsBuy.Length);
        for (int i = 0; i < models.Count; i++)
        {
            equipmentsBuy[i].Create(models[i]);
        }
    }

    void BuyRandom()
    {
        if (ResourceController.instance.DecreaseResource(resourceBuyRandom, priceRandom))
        {
            IItemModel model = InventoryManager.instance.ItemModelContainer.GetRandomModel();
            StartSceenManager.instance.OpenPopupShowItem(model.Icon);
            BuyItem(model);
        }
        else {
            StartSceenManager.instance.OpenPopupDebug("Khong du tien");
        }
    }

}
