using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : Singleton<CameraMain>
{
    private Vector3 minCameraBounds;
    private Vector3 maxCameraBounds;
    private Vector2 size;

    public Vector3 MinCameraBounds => minCameraBounds;
    public Vector3 MaxCameraBounds => maxCameraBounds;

    public float Diagonal => Mathf.Sin(45 * Mathf.Deg2Rad) * size.y;

    public Vector2 Size => size;

    private void Start()
    {
        minCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = camHeight * Camera.main.aspect;
        size =  new Vector2 (camWidth, camHeight);
    }
    private void Update()
    {
        minCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxCameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

    }
}
