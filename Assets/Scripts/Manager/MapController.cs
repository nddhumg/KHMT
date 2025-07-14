using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] protected PolygonCollider2D col;

    public Collider2D Col => col;
}
