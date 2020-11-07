using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxAttackParticle : MonoBehaviour
{
    public float DelayToAttack = 0.3f;
    Enemy enemy;
    bool canSetDamage;

    void Start()
    {
        canSetDamage = true;
        enemy = transform.parent.GetComponent<Enemy>();
    }
    void OnTriggerStay(Collider other)
    {
        if (canSetDamage && other.tag == "Player")
        {
            canSetDamage = false;
            StartCoroutine(Attack());
        }
    }
    void OnTriggerExit(Collider other)
    {
        StopCoroutine(Attack());
        canSetDamage = true;
    }
    IEnumerator Attack()
    {
        Player.Instance.SetDamage(enemy.Damage);
        yield return new WaitForSeconds(1f);
        canSetDamage = true;
    }
}
