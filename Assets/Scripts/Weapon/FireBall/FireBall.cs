using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall :  Weapon
{
    [SerializeField] protected int perFire = 3;
    [SerializeField] protected float recoildAmount = 0.3f;

    private void Reset()
    {
        damageMultiplier = 2f;
        attackSpeed = 3;
        muzzle = transform;
    }

    public void IncreasePrerFire(int value) { 
        perFire += value;
    }
    protected override Vector2 GetAttackDirection()
    {
        return Random.insideUnitCircle.normalized;
    }
    protected override void Attack()
    {
        StartCoroutine(CreateFireBall());
    }
    protected IEnumerator CreateFireBall()
    {
        GameObject bulletCurrent;
        float recoil = 0;
        Vector2 directionBullet = GetAttackDirection();
        Quaternion rotationBullet = new Quaternion();
        Vector2 vectoBullet;
        for (int countAmmo = 0; countAmmo < perFire; countAmmo++)
        {
            Vector2 directionBulletCurrent = directionBullet;
            recoil = Random.Range(-recoildAmount, recoildAmount);
            if (Random.value > 0.5)
                directionBulletCurrent.y += recoil;
            else
                directionBulletCurrent.x += recoil;
            rotationBullet = Quaternion.Euler(0f,0f, directionBullet.x > 0 ? Vector2.Angle(Vector2.down, directionBullet) : -Vector2.Angle(Vector2.down, directionBullet));
            bulletCurrent = BulletPool.instance.GetFromPool(this.bullet, muzzle.position, rotationBullet);
            bulletCurrent.GetComponentInChildren<MoveInDirection>().Direction = directionBulletCurrent;
            bulletCurrent.GetComponentInChildren<DamageSender>().SetDamage((int)Player.instance.StatsManager.GetStatValue(EnumName.Stat.Damage));

            yield return new WaitForSeconds(Random.Range(0, 0.1f));
        }
        timer.ResetCoolDown();
        yield return null;
    }

    
}
