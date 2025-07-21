using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Manager/Container/Boss", fileName = "ContainerBoss")]
public class SOContainerBoss : ScriptableObject, IContainerBoss
{
    [SerializeField]List<BossContainer> bossContainers = new List<BossContainer>();

    [System.Serializable]
    private class BossContainer
    {
        public BossId id;
        public GameObject boss;
    }
    public GameObject GetBoss(string id)
    {
        return bossContainers.Find(boss => boss.id.ToString() == id).boss;
    }

    public GameObject GetBoss(BossId id)
    {
        return bossContainers.Find(boss => boss.id == id).boss;
    }
}
