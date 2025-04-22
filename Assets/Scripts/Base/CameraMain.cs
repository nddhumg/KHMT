using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : Singleton<CameraMain>
{
    private Vector3 minCameraBounds;
    private Vector3 maxCameraBounds;

    public Vector3 MinCameraBounds => minCameraBounds;
    public Vector3 MaxCameraBounds => maxCameraBounds;


    private void Update()
    {
        minCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

    }
}
