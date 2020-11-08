using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackCapsule : MonoBehaviour
{
    public float Damage = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SetDamage(Damage);
        }
    }
}
