using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SpawnRate
{
    [SerializeField] private float rate;
    [SerializeField] private GameObject prefab;

    public float Rate => rate;

    public GameObject Prefab => prefab;
}