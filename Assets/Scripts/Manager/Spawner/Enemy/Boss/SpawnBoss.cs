using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;
using Core.Spawn.Enemy;

public class SpawnBoss : MonoBehaviour
{
    private GameObject bossNext;
    private ISpawnZone spawnZone;
    private IBossSpawnData spawnData;
    private int indexSpawnBoss = 0;
    private IContainerBoss bossContaiener;
    private ICoolDownAuto coolDown;
    private bool isActiveEffectWarning;

    [SerializeField] private SOContainerBoss soContainerBoss;
    [SerializeField] private SOBossSpawn soBossSpawn;


    private void Start()
    {
        spawnZone = GameController.instance.SpawnZone;
        bossContaiener = soContainerBoss;
        spawnData = soBossSpawn.GetBossSpawnPlan(GameController.instance.MapId);
        if (spawnData == null)
        {
            Destroy(gameObject);
            return;
        }

        bossNext = bossContaiener.GetBoss(spawnData.BossSpawnEntry[indexSpawnBoss].bossid);
        coolDown = new AutoCooldownTimer(spawnData.BossSpawnEntry[indexSpawnBoss].timeSpawn,1f/60,Spawn,countUp: false);
    }

    void Update()
    {
        coolDown.UpdateCooldown(Time.deltaTime);
        if (coolDown.Timer <= 5 && !isActiveEffectWarning) {
            MusicManager.instance.PlaySFX(MusicKey.Warning);
            isActiveEffectWarning = true;
        }
    }

    void Spawn()
    {
        Instantiate(bossNext, spawnZone.GetRandomSpawnPosition(), Quaternion.identity);
        if (indexSpawnBoss < spawnData.BossSpawnEntry.Count - 1)
        {
            indexSpawnBoss++;
            bossNext = bossContaiener.GetBoss(spawnData.BossSpawnEntry[indexSpawnBoss].bossid);
            coolDown.Cooldown = spawnData.BossSpawnEntry[indexSpawnBoss].timeSpawn;
        }
        else
        {
            StopSpawnBoss();
        }
        isActiveEffectWarning = false;
    }

    void StopSpawnBoss()
    {
        coolDown.Pause();
    }

}
