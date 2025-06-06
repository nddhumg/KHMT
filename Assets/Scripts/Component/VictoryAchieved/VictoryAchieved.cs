using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VictoryAchieved 
{
    public void Update()
    {
        if (CanVictory())
        {
            Victory();
        }
    }

    protected abstract bool CanVictory();

    protected void Victory()
    {
        ScreenGameOver.instance.Victory();
    }
}
