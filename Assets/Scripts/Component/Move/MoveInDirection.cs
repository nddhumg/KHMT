using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] protected bool canMove = true;

    public Vector3 Direction
    {
        get { return direction; }

        set
        {
            direction = value;
            direction.Normalize();
        }
    }

    public float Speed
    {
        set
        {
            speed = value;
        }
    }


    public bool CanMove {
        set {
            canMove = value;
        }
    }

    void Update()
    {
        if (!canMove)
            return;
        transform.parent.position += speed * Time.deltaTime * direction;
    }


}
