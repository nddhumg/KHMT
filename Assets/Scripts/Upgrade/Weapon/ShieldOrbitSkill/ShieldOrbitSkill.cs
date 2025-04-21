using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldOrbitSkill : MonoBehaviour
{
    [SerializeField] protected GameObject shieldPrefab;
    protected List<Transform> shieldProjectiles = new List<Transform>();

    [SerializeField] protected float shieldRotationSpeed = 80;
    [SerializeField] protected float shieldOrbitRadius = 1.5f;
    [SerializeField] protected float damageMultiplier = 1;
    protected Vector3 rotate = Vector3.zero;
    protected SOStat statPlayer;

    private void Start()
    {
        statPlayer = Player.instance.StatsManager.StatCurrent;
        statPlayer.OnChangeStat += UpdatePlayerDamage;
        SpawnShield();
    }


    private void Update()
    {
        rotate.z += Time.deltaTime * shieldRotationSpeed;
        if (rotate.z >= 360)
            rotate = Vector3.zero;
        transform.localRotation = Quaternion.Euler(rotate);

    }
    [Button]
    public void SpawnShield()
    {
        Transform shieldCreate = Instantiate(shieldPrefab, transform).transform;
        shieldProjectiles.Add(shieldCreate);
        DamageSender damageSender = shieldCreate.GetComponentInChildren<DamageSender>();
        int damage = (int)(statPlayer.GetStatValue(EnumName.Stat.Damage) * damageMultiplier);
        damageSender.SetDamage(damage);

        UpdatePositionShield();
    }

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
        ChangeDamage(statPlayer.GetStatValue(EnumName.Stat.Damage));
    }

    public void IncreaseRotationSpeed(float value)
    {
        this.shieldRotationSpeed += value;
    }

    public void IncreaseOrbitRadius(float value)
    {
        this.shieldOrbitRadius += value;
        UpdatePositionShield();
    }

    protected void UpdatePlayerDamage(EnumName.Stat key, float damage)
    {
        if (key != EnumName.Stat.Damage)
            return;
        foreach (Transform shield in shieldProjectiles)
        {
            shield.GetComponentInChildren<DamageSender>().SetDamage((int)(damage * damageMultiplier));

        }
    }

    protected void ChangeDamage(float damage)
    {
        foreach (Transform shield in shieldProjectiles)
        {
            shield.GetComponentInChildren<DamageSender>().SetDamage((int)(damage * damageMultiplier));
        }
    }

    protected void UpdatePositionShield()
    {
        float angle = 360f / shieldProjectiles.Count;
        float angleCurrent = 0;
        Vector2 postionShield = Vector3.zero;
        for (int i = 0; i < shieldProjectiles.Count; i++)
        {

            postionShield.y = Mathf.Sin(angleCurrent * Mathf.PI / 180) * shieldOrbitRadius;
            postionShield.x = Mathf.Cos(angleCurrent * Mathf.PI / 180) * shieldOrbitRadius;
            shieldProjectiles[i].localPosition = postionShield;
            angleCurrent += angle;
        }
    }
}
