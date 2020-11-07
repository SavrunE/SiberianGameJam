using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    ParticleSystem particleSystemAttack;
    Lighting light;
    public float Damage = 1f;
    public float DamageReduct = 10f;

    void Start()
    {
        light = GetComponent<Lighting>();
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
        light.ActivateLight(true);
        SetSelfDamage();
    }
    void AttackerStop()
    {
        light.ActivateLight(false);
        particleSystemAttack.Stop();
    }
    private void SetSelfDamage()
    {
        EnergyBarUI.Instance.Health -= Damage/DamageReduct * Time.deltaTime;
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
