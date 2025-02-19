using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSystem
{
    private static bool isPause;
    private static int coin = 0 ;

    public static bool IsPause => isPause;
    public static int Coin => coin;

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
    }
}
