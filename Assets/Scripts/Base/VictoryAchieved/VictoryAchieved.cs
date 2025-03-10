using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VictoryAchieved : MonoBehaviour
{
    protected void Update()
    {
        if (CanVictory())
        {
            Victory();
        }
    }

    protected abstract bool CanVictory();

    protected  void Victory()
    {
        ScreenGameOver.instance.Victory();
    }
}
