using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : PersistentSingleton<Inventory>
{
    [SerializeField]protected List<SOItem> itemsCurrent;
    protected SOItem[] equippedItems =  new SOItem[4]; 

    public List<SOItem> ItemsCurrent => itemsCurrent;
    public void AddItem(SOItem item) {
        itemsCurrent.Add(item);
    }

    
}
