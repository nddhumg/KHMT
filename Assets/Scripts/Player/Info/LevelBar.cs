using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBar : SliderGameObject
{
    PlayerLevel level;

    private void Start()
    {
        level = Player.instance.Level;
    }
    private void Update()
    {
        this.Value = (float)level.Exp / level.ExpLevelUp; 
    }
}
