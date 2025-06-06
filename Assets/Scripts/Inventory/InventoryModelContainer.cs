using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public IItemModel GetRandomModel()
    {
        return itemModel.ElementAt(Random.Range(0, itemModel.Count)).Value;
    }
    public List<IItemModel> GetRandomModels(int count)
    {
        List<IItemModel> randomModels = new List<IItemModel>();
        for (int i = 0; i < count; i++)
        {
            randomModels.Add(GetRandomModel());
        }
        return randomModels;
    }
}
