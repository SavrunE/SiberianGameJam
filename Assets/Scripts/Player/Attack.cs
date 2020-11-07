using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    ElectricityAttack electricityAttack;
    public float Damage = 1f;
    public float SelfDamageReduction = 10f;

    void Start()
    {
        electricityAttack = GetComponent<ElectricityAttack>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            AttackerStart();
        else
            AttackerStop();
    }
    void AttackerStart()
    {
        electricityAttack.Activate(true);
        SetSelfDamage();
    }
    void AttackerStop()
    {
        electricityAttack.Activate(false);
    }
    private void SetSelfDamage()
    {
        EnergyBarUI.Instance.Health -= Damage / SelfDamageReduction * Time.deltaTime;
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
