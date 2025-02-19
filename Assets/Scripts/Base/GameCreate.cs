using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreate : MonoBehaviour
{
    [SerializeField] protected GameObject uiStatic;
    [SerializeField] protected GameObject ui;

    protected void Awake()
    {
        Instantiate(uiStatic);
        Instantiate(ui);
    }
}
