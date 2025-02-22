using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSystem
{
    public enum Resource{ 
        Coin,
        CoinVip,
        Energy,
    }
    private static bool isPause;
    private static int coin = 0 ;
    private static int coinVip = 0 ;
    private static int energy = 0;
    private static int energyMax = 30 ;
    public static Action<Resource> onChangeResource;

    public static bool IsPause => isPause;
    public static int Coin => coin;
    public static int CoinVip => coinVip;
    public static int Energy => energy;
    public static int EnergyMax => energyMax;


    public static void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    public static void RePause() {
        isPause = false;
        Time.timeScale = 1;
    }

    public static void AddCoin(int value){
        coin += value;
        onChangeResource(Resource.Coin);
    }
    public static void AddCoinVip(int value)
    {
        coinVip += value;
        onChangeResource(Resource.CoinVip);
    }

    public static void IncreaseResource(Resource resource, int value) {
        if (resource == Resource.Coin)
        {
            coin += value;
            onChangeResource(resource);
        }
        else if (resource == Resource.CoinVip)
        {
            coinVip += value;
            onChangeResource(resource);
        }
        else { 
            energy += value;
            onChangeResource(resource);
        }
    }
}
