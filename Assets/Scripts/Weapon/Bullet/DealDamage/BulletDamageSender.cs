using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    protected override bool Send(IReceiveDamage receive)
    {
        if (base.Send(receive)) { 
            transform.parent.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
