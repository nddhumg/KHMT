using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    [SerializeField] protected SkillSlot[] slots;
    protected int slotCurrent = 0;

    private void Start()
    {
        Player.instance.SkillManager.OnUpgradeApplied += (data) => AddSkill(data.Icon);
        foreach (SkillSlot slot in slots) { 
            slot.gameObject.SetActive(false);
        }
    }

    public void AddSkill(Sprite sprite ) {
        slots[slotCurrent].SetIcon(sprite);
        slotCurrent++;
    }
}
