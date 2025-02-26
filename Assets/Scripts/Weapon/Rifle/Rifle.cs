using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    [SerializeField] protected float maxAmmo = 5f;
    [SerializeField] protected float recoildAmount = 0.1f;
    //[SerializeField] protected Tr

    private void Reset()
    {
        damageMultiplier = 0.5f;
        attackSpeed = 1.5f;
    }
    void Start()
    {
        timer.SetAutoResetCoolDown(false);
    }

    protected override void Attack()
    {
        StartCoroutine(CreateBullet());
    }

    protected IEnumerator CreateBullet() {
        GameObject bulletCurrent;
        float recoil = 0;
        Vector2 directionBullet;
        for (int countAmmo = 0; countAmmo < maxAmmo; countAmmo++)
        {
            recoil = Random.Range(-recoildAmount, recoildAmount);
            directionBullet = GetAttackDirection();
            if (Random.value > 0.5)
                directionBullet.y += recoil;
            else
                directionBullet.x += recoil;
            bulletCurrent = BulletPool.instance.Spawn(bullet, transform.position, Quaternion.identity);
            bulletCurrent.GetComponentInChildren<MoveInDirection>().Direction = directionBullet;
            bulletCurrent.GetComponentInChildren<DamageSender>().SetDamage((int)Player.instance.StatsManager.StatCurrent.GetStatValue(EnumName.Stat.Damage));
            yield return new WaitForSeconds(Random.Range(0, 0.1f));
        }
        timer.ResetCoolDown();
        yield return null;
    }

}
