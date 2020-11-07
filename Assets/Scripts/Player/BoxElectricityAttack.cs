using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxElectricityAttack : MonoBehaviour
{
    Attack attack;
    void Start()
    {
        attack = transform.parent.GetComponent<Attack>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SetDamage(attack.Damage * Time.deltaTime);
        }
    }
}
