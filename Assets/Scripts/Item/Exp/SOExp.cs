using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="exp",menuName ="SO/Item/Exp")]
public class SOExp : ScriptableObject
{
    [SerializeField] protected uint expvalue;

    public uint ExpValue => expvalue;

}
