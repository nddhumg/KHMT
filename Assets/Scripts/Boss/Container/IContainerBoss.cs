using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainerBoss
{
    GameObject GetBoss(string id);
    GameObject GetBoss(BossId id);
}
