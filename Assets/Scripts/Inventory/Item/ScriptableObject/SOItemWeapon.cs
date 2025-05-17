using EnumName;
using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Item/Weapon" , fileName ="weapon")]
public class SOItemWeapon : SOItem
{
    [SerializeField] protected EnumName.WeaponName weaponName;


    public SOItemWeapon() : base(EnumName.EquipmentType.Weapon)
    {
    }

    public override string NameItem => weaponName.ToString();
}
