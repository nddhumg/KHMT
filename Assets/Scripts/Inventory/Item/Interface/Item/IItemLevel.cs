using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemLevel
{
    Action<int> OnLevelUp{ get; set; }
    public int Level { get;  }
    public void LevelUp();
    public void LevelUp(int level);
}
