using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;


public interface IItemBonusStat
{
    public IEquipmentStats EquipmentStats { get; }

    float GetBonusStat( );
}
