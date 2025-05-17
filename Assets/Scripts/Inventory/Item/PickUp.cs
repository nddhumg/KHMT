using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PickUp : MonoBehaviour
{
    [SerializeField] protected float pickupRange = 0.5f;
    protected CircleCollider2D circleCollider2D;

    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.radius = pickupRange;
        circleCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickUpItem(collision.gameObject);
    }

    void PickUpItem(GameObject item)
    {
        IItemPickUp itemScript = item.GetComponent<IItemPickUp>();
        if (itemScript != null)
            itemScript.PickUpAble();
    }
}
