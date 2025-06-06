using EnumName;
using System;
using System.Collections;
using System.Collections.Generic;
using Systems.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField, ReadOnly] protected ShopData data;
    string format = "dd-MM-yyyy";

    [Header("Panel Shop")]
    [SerializeField] private GameObject shopResource;
    [SerializeField] private GameObject shopEquipment;

    [Header("Btn ChangShop")]
    [SerializeField] private Button btnChangeShopResource;
    [SerializeField] private Button btnChangeShopEquipment;

    private ShopName currentShop;
    private GameObject currentPanelShop;
    public enum ShopName
    {
        Equipment,
        Resource,
    }

    public ShopData Data => data;
    public string FormatTime => format;


    private void OnApplicationQuit()
    {
        SaveLoadSystem.DataService.Save<ShopData>(ref data);
    }

    private void Start()
    {
        data = SaveLoadSystem.DataService.Load<ShopData>(gameObject) ?? new();

        btnChangeShopResource.onClick.AddListener(() => ChangeShop(ShopName.Resource));
        btnChangeShopEquipment.onClick.AddListener(() => ChangeShop(ShopName.Equipment));

        ChangeShop(ShopName.Resource);
    }

    public void ChangeShop(ShopName shopName)
    {
        if (shopName == currentShop)
            return;
        currentShop = shopName;
        EnablePanelShop(shopName);
    }

    protected void EnablePanelShop(ShopName shopName)
    {
        currentPanelShop?.SetActive(false);
        GameObject panel = GetPanelShop(shopName);
        panel.SetActive(true);
        currentPanelShop = panel;
    }

    protected GameObject GetPanelShop(ShopName shopName)
    {
        switch (shopName)
        {
            case ShopName.Resource:
                return shopResource;
            case ShopName.Equipment:
                return shopEquipment;
            default:
                return null;
        }
    }
}

