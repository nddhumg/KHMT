using System;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

[Serializable]
public class EquipmentPriceContainer
{
    [SerializeField] List<EquipmentPrice> equipmentPrices = new List<EquipmentPrice>();

    public EquipmentPrice GetEquipmentPrice(EquipmentType equipmentType) {
        return equipmentPrices.Find(equipment => equipment.type == equipmentType);
    }
}

[Serializable]
public class EquipmentPrice
{
    public EquipmentType type;
    public ResourceName resource;
    public uint price;
} 
