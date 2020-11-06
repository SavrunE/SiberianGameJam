using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    ParticleSystem particleSystemAttack;
    public float Damage = 1f;
    public float DamageReduct = 10f;

    void Start()
    {
        particleSystemAttack = transform.Find("Electricity").GetComponent<ParticleSystem>();
        particleSystemAttack.Stop();
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
        particleSystemAttack.Play();
        SetSelfDamage();


    }
    void AttackerStop()
    {
        particleSystemAttack.Stop();
    }
    private void SetSelfDamage()
    {
        EnergyBarUI.Instance.Health -= Damage/DamageReduct * Time.deltaTime;
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
