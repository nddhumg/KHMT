using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapData
{
    List<InterfaceReference<IWinConditionData>> AnyWinCondition { get; }
    List<InterfaceReference<IWinConditionData>> AllWinCondition { get; }
}
