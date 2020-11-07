using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    ParticleSystem attackParticle;
    BoxCollider attackerBox;
    void Awake()
    {
        attackerBox = transform.Find("BoxAttackParticle").GetComponent<BoxCollider>();
        attackerBox.enabled = false;
        attackParticle = transform.Find("AttackParticle").GetComponent<ParticleSystem>();
        attackParticle.Stop();
    }
    public void Boom()
    {
        attackParticle.Play();
        attackerBox.enabled = true;
        StopCoroutine(StopAttack());
    }
    IEnumerator StopAttack()
    {
        yield return null;
        attackParticle.Stop();
        attackerBox.enabled = false;
    }
}
