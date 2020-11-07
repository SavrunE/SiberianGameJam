using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityAttack : MonoBehaviour
{
    Light light;
    ParticleSystem attackLight;
    void Start()
    {
        Transform electricityAttack = transform.Find("ElectricityAttack");
        attackLight = electricityAttack.GetComponent<ParticleSystem>();
        light = electricityAttack.GetComponent<Light>();

        attackLight.Stop();
        light.enabled = false;
    }
    public void Activate(bool value)
    {
        if (value)
        {
            attackLight.Play();
            light.enabled = true;
        }
        else
        {
            attackLight.Stop();
            light.enabled = false;
        }
    }
}
