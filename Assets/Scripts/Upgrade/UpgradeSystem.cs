﻿using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;


public class UpgradeSystem : Singleton<UpgradeSystem>
{
    [SerializeField] protected List<UpgradeSelect> upgradesSelect;
    [SerializeField] protected List<SOUpgrade> availableUpgrades;
    [SerializeField] protected List <SOUpgradeWeapon> weaponBase;
    protected int countUpgradeSelect = 3;
    protected List<SOUpgrade> infoUpgradeSelect = new List<SOUpgrade>();

    protected override void Awake()
    {
        base.Awake();
        SetActiveUpgrade(false);
        AddUpgradeWeapon();
    }
    [Button]
    public void AddUpgradeWeapon()
    {
        foreach(var weapon in weaponBase)
        {
            if (weapon.SkillName.ToString() == InventoryManager.instance.EquippedWeapon.nameItem.ToString()) { 
                availableUpgrades.Add(weapon);
                weapon.ApplyUpgrade();
                Player.instance.SkillManager.GetGameObj(weapon.SkillName.ToString()).transform.localPosition = weapon.Position;
                return;
            }
        }
    }

    public virtual void CreateUpgrade()
    {

        List<SOUpgrade> available = new List<SOUpgrade>(availableUpgrades);

        System.Random random = new();
        infoUpgradeSelect.Clear();
        for (int i = 0; i < countUpgradeSelect; i++)
        {
            int index = random.Next(available.Count);
            infoUpgradeSelect.Add(available[index]);
            available.RemoveAt(index);
        }
        for (int i = 0; i < countUpgradeSelect; i++)
        {
            upgradesSelect[i].SetInfo(i, infoUpgradeSelect[i].Icon, infoUpgradeSelect[i].GetDescription());
        }
        SetActiveUpgrade(true);
        GameSystem.Pause();
    }

    private void SetActiveUpgrade(bool isActive)
    {
        foreach (UpgradeSelect upgrade in upgradesSelect)
        {
            upgrade.gameObject.SetActive(isActive);
        }
    }

    public void ApllyUpgrade(int index)
    {
        infoUpgradeSelect[index].ApplyUpgrade();
        SetActiveUpgrade(false);
        GameSystem.RePause();

    }

}
