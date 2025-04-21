using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;


public class UpgradeSystem : Singleton<UpgradeSystem>
{
    [SerializeField] protected List<UpgradeSelect> upgradesSelect;
    [SerializeField] protected List<SOUpgradeStats> availableUpgradesStat;
    [SerializeField] private List<SOUpgradeSkill> availableUpgradesSkill;
    [SerializeField] protected List<SOUpgradeWeapon> weaponBase;
    protected int countUpgradeSelect = 3;
    protected List<SOUpgrade> infoUpgradeSelect = new List<SOUpgrade>();

    protected override void Awake()
    {
        base.Awake();
        SetActiveUIUpgrade(false);
        AddUpgradeWeapon();
    }

    public void AddUpgradeWeapon()
    {
        foreach (var weapon in weaponBase)
        {
            if (weapon.SkillName.ToString() == InventoryManager.instance.EquippedWeapon.nameItem.ToString())
            {
                availableUpgradesSkill.Add(weapon);
                weapon.ApplyUpgrade();
                Player.instance.SkillManager.GetGameObj(weapon.SkillName.ToString()).transform.localPosition = weapon.Position;
                return;
            }
        }
    }

    public void UppgradeSkill(SOUpgradeSkill UpgradeSkill) { 
        UpgradeSkill.ApplyUpgrade();
    }

    [Button]
    public virtual void CreateUpgrade()
    {

        List<SOUpgrade> available = new List<SOUpgrade>(availableUpgradesStat);
        available.AddRange(availableUpgradesSkill);

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
        SetActiveUIUpgrade(true);
        GameSystem.Pause();
    }

    public SOUpgradeSkill GetRandomUpgradeSkill(){
        return availableUpgradesSkill[Random.Range(0,availableUpgradesSkill.Count)];
    }

    public virtual void RemoveUpgradeSkill(SOUpgradeSkill upgrade)
    {
        availableUpgradesSkill.Remove(upgrade);
    }

    public bool CanUpgradeSkill() { 
        return availableUpgradesSkill.Count > 0;
    }

    private void SetActiveUIUpgrade(bool isActive)
    {
        foreach (UpgradeSelect upgrade in upgradesSelect)
        {
            upgrade.gameObject.SetActive(isActive);
        }
    }

    public void ApllyUpgrade(int index)
    {
        infoUpgradeSelect[index].ApplyUpgrade();
        SetActiveUIUpgrade(false);
        GameSystem.RePause();

    }

}
