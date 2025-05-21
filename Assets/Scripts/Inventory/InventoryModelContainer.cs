using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;

public class InventoryModelContainer : IItemDataBase
{
    private Dictionary<string, SOItem> itemModel;
    public InventoryModelContainer(List<SOItem> itemCollection)
    {
        itemModel = new Dictionary<string, SOItem>();
        foreach (SOItem model in itemCollection)
        {
            itemModel.Add(model.NameItem, model);
        }
    }

    public IItemModel GetModelByName(string name) => itemModel[name];

}
