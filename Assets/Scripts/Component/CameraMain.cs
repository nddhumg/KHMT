using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : Singleton<CameraMain>
{
    private Vector2 size;

    [SerializeField] private CinemachineConfiner2D confiner2D;


    public Vector3 CameraBottomLeft => Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
    public Vector3 CameraTopRight => Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    public Vector3 CameraTopLeft => Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
    public Vector3 CameraBottomRight => Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

    public float Diagonal => Mathf.Sin(45 * Mathf.Deg2Rad) * size.y;

    public Vector2 Size => size;

    private void Start()
    { 

        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = camHeight * Camera.main.aspect;
        size = new Vector2(camWidth, camHeight);
    }

    public void SetConfinerCollider(Collider2D collider2D)
    {
        this.confiner2D.m_BoundingShape2D = collider2D;
    }

    public Vector2 GetRandomPointInBounded(out Vector2 side)
    {
        if (Random.value < 0.5)
        {
            side.x = -1;
            side.y = Random.Range(0, 2);
            return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1), side.y, 0));
        }
        else
        {
            side.y = -1;
            side.x = Random.Range(0, 2);
            return Camera.main.ViewportToWorldPoint(new Vector3(side.x, Random.Range(0f, 1), 0));
        }
    }
    /// <summary>
    /// Returns a random world point along one side of the camera's viewport.
    /// 
    /// Valid sideAnchor values:
    ///   (0, ?) → left edge
    ///   (1, ?) → right edge
    ///   (?, 1) → top edge
    ///   (?, 0) → bottom edge
    /// 
    /// </summary>
    public Vector2 GetRandomPointInBounded(Vector2 sideSelect) {
        if (sideSelect.x == -1 && sideSelect.x != -1)
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(sideSelect.x, Random.Range(0f, 1), 0));
        }
        else if (sideSelect.y == -1 && sideSelect.x != -1) {
            return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1), sideSelect.y, 0));
        }
        //Debug.LogWarning();
        return Vector2.zero;
    }
}
