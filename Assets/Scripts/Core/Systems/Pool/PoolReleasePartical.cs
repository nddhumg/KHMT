using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReleasePartical : MonoBehaviour
{

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
