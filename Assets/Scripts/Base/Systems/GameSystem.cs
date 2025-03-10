using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSystem
{
    private static bool isPause;

    private static DateTime timeNow = DateTime.Now ;

    public static bool IsPause => isPause;


    public static void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    public static void RePause() {
        isPause = false;
        Time.timeScale = 1;
    }
    
}
