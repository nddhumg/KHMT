using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using System;

[Serializable]
public class TutorialData : ISaveable
{
    public string ID { get; set; }
    public bool isFirstInGame = true;

}
