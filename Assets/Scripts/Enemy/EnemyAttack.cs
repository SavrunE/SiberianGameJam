using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    ParticleSystem attackParticle;
    void Awake()
    {
        attackParticle = transform.Find("AttackParticle").GetComponent<ParticleSystem>();
        attackParticle.Stop();
    }
    public void Boom()
    {
        attackParticle.Play();
        Debug.Log("BOOM");
    }
}
