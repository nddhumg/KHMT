using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected MoveInDirection moveInDirection;
    [SerializeField] protected DamageSender damageSender;
    public void SetDirection(Vector3 direction) {
        float angle = Vector2.Angle(Vector2.right, direction);
        transform.rotation = Quaternion.Euler(0, 0, direction.y > 0 ? angle : -angle);
        moveInDirection.Direction = direction;
    }
    public void SetDamage(int damage) {
        damageSender.SetDamage(damage);
    }

}
