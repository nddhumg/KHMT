using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Upgrade/Weapon")]
public class SOUpgradeWeapon : SOUpgradeSkill 
{
    [SerializeField]protected Vector3 position;

    public Vector3 Position => position;
}
