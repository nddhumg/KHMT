using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Vector3 direction = Vector3.right;

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

    void Update()
    {
        transform.parent.position += speed * Time.deltaTime * direction;
    }

}
