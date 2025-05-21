using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Inventory/ContainerModel")]
public class SOItemContainerModel : ScriptableObject
{
    [SerializeField] private List<SOItem> itemCollection;

    public List<SOItem> ItemCollection => itemCollection;
}
