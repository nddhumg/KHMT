using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "SO/Map/MapData")]
public class SOMap : ScriptableObject, IMapData
{
    [SerializeField] protected List<InterfaceReference<IWinConditionData>> anyWinConditions;
    [SerializeField] protected List<InterfaceReference<IWinConditionData>> allWinConditions;

    [SerializeField] protected string id;
    [SerializeField] protected GameObject map;
    [SerializeField] protected MusicKey musicKey;

    public GameObject Map => map;

    public List<InterfaceReference<IWinConditionData>> AnyWinCondition => anyWinConditions;

    public List<InterfaceReference<IWinConditionData>> AllWinCondition => allWinConditions;

    public MusicKey MusicKey => musicKey;
}
