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
    protected Player player;

    //[SerializeField] protected int maxUpgradeSkill = 5;
    //protected int countUpgradeSkill = 0;

    protected override void Awake()
    {
        base.Awake();
        SetActiveUIUpgrade(false);
    }

    private void Start()
    {
        player = Player.instance;
        AddUpgradeWeapon();
    }
    public void ApllyUpgrade(int index)
    {
        MusicManager.instance.PlaySFX(MusicKey.SelectUpgrade);
        infoUpgradeSelect[index].ApplyUpgrade(player);
        SetActiveUIUpgrade(false);
        GameSystem.RePause();
    }

    public void AddUpgradeWeapon()
    {
        IItemData weaponInInventory = InventoryManager.instance.EquippedWeapon;
        SOUpgradeWeapon weaponUpgrade = null;
        if (weaponInInventory.ModelData == null)
        {
            weaponUpgrade = weaponBase[0];
        }
        else
        {
            foreach (var weapon in weaponBase)
            {
                if (weapon.SkillName.ToString() == weaponInInventory.ModelData.NameItem.ToString())
                {
                    weaponUpgrade = weapon;
                    break;
                }
            }
            weaponUpgrade = weaponUpgrade != null ? weaponUpgrade : weaponBase[0];
        }
        availableUpgradesSkill.Add(weaponUpgrade);
        weaponUpgrade.ApplyUpgrade(player);
        GameObject weaponGO = Player.instance.SkillManager.GetGameObj(weaponUpgrade.SkillName.ToString());
        weaponGO.transform.localPosition = weaponUpgrade.Position;
        Player.instance.SetWeapon(weaponGO);
    }

    [Button]
    public virtual void CreateUpgrade()
    {

        List<SOUpgrade> available = new List<SOUpgrade>(availableUpgradesStat);
        //if(!IsMaxUpgradeSkill())
            available.AddRange(availableUpgradesSkill);

        System.Random random = new();
        infoUpgradeSelect.Clear();
        for (int i = 0; i < countUpgradeSelect; i++)
        {
            int index = random.Next(available.Count);
            infoUpgradeSelect.Add(available[index]);
            available.RemoveAt(index);
            upgradesSelect[i].SetInfo(i, infoUpgradeSelect[i].Icon, infoUpgradeSelect[i].GetDescription(player));
        }
        SetActiveUIUpgrade(true);
        GameSystem.Pause();
    }

    public SOUpgradeSkill GetRandomUpgradeSkill()
    {
        return availableUpgradesSkill[Random.Range(0, availableUpgradesSkill.Count)] ;
    }

    public virtual void RemoveUpgradeSkill(SOUpgradeSkill upgrade)
    {
        availableUpgradesSkill.Remove(upgrade);
    }

    public bool CanUpgradeSkill()
    {
        return availableUpgradesSkill.Count > 0 ;
    }

    //private bool IsMaxUpgradeSkill()
    //{
    //    return countUpgradeSelect == maxUpgradeSkill;
    //}

    private void SetActiveUIUpgrade(bool isActive)
    {
        foreach (UpgradeSelect upgrade in upgradesSelect)
        {
            upgrade.gameObject.SetActive(isActive);
        }
    }

    

}
