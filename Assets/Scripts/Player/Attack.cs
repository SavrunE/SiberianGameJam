using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    ElectricityAttack electricityAttack;
    public float Damage = 10f;
    public float SelfDamageReduction = 10f;

    BoxCollider attackBox;
    void Start()
    {
        attackBox = transform.Find("AttackBox").GetComponent<BoxCollider>();
        attackBox.enabled = false;
        electricityAttack = GetComponent<ElectricityAttack>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
            AttackerStart();
        else
            AttackerStop();
    }
    void AttackerStart()
    {
        electricityAttack.Activate(true);
        SetSelfDamage();
        attackBox.enabled = true;
    }
    void AttackerStop()
    {
        electricityAttack.Activate(false);
        attackBox.enabled = false;
    }
    void SetSelfDamage()
    {
        float damage = Damage / SelfDamageReduction;
        Player.Instance.SetDamage(damage * Time.deltaTime);
    }
}
