using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private GameObject healingEffect;
    [SerializeField] private SpriteRenderer sprite;

    protected bool isActiveEffectTakeDamage;
    public void ActiveEffectHealing()
    {
        healingEffect.SetActive(true);
    }

    public void ActiveEffectTakeDamage()
    {
        if (!isActiveEffectTakeDamage)
            StartCoroutine(EffectTakeDamage());
    }

    protected IEnumerator EffectTakeDamage()
    {
        isActiveEffectTakeDamage = true;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
        isActiveEffectTakeDamage = false;
    }
}
