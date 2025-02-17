using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall :  Weapon
{
    [SerializeField] protected int perFire = 3;
    [SerializeField] protected GameObject fireBallPrefab;
    [SerializeField] protected float recoildAmount = 0.1f;


    private void Reset()
    {
        damageMultiplier = 2f;
        attackSpeed = 3;
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
        for (int countAmmo = 0; countAmmo < perFire; countAmmo++)
        {
            Vector2 directionBulletCurrent = directionBullet;
            recoil = Random.Range(-recoildAmount, recoildAmount);
            if (Random.value > 0.5)
                directionBulletCurrent.y += recoil;
            else
                directionBulletCurrent.x += recoil;
            bulletCurrent = BulletPool.instance.GetFromPool(fireBallPrefab, transform.position, Quaternion.identity);
            bulletCurrent.GetComponentInChildren<MoveInDirection>().Direction = directionBulletCurrent;
            bulletCurrent.GetComponentInChildren<DamageSender>().SetDamage((int)Player.instance.StatsManager.GetStatValue(EnumName.Stat.Damage));
            yield return new WaitForSeconds(Random.Range(0, 0.1f));
        }
        timer.ResetCoolDown();
        yield return null;
    }

    
}
