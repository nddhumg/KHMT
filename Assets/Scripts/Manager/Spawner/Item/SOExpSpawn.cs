using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Spawn/ExpRate")]
public class SOExpSpawn : ScriptableObject
{

    [SerializeField] protected List<GameObject> expPrefabs = new List<GameObject>();
    [SerializeField,ArrayElementTitle("timeChange")] protected List<ExpRate> expRates;

    public List<GameObject> ExpPrefabs => expPrefabs;
    public List<ExpRate> ExpRates => expRates;
}
[System.Serializable]
public class ExpRate
{
    [SerializeField]
    float[] rate;

    [SerializeField] float timeChange;

    public float[] Rate => rate;
    public float TimeChange => timeChange;
}


