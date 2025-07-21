using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private GameObject healingEffect;
    [SerializeField] private SpriteRenderer sprite;
    public void ActiveEffectHealing()
    {
        healingEffect.SetActive(true);
    }

    public void ActiveEffectTakeDamage() {
        StartCoroutine(EffectTakeDamage());
    }

    protected IEnumerator EffectTakeDamage() {

        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
