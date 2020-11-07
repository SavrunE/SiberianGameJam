using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    Light light;
    float lightOverpower = 10f;
    void Start()
    {
        light = transform.Find("LightOnHit").GetComponent<Light>();

        light.enabled = false;
    }

    public void ActivateLightOnDamage(float damage)
    {
        light.enabled = true;
        light.range = damage * lightOverpower;
    }
    public void DeactivateLightOnDamage()
    {
        while (light.range > 0)
        {
            light.range -= lightOverpower * Time.deltaTime;
        }
        light.enabled = false;
    }
}
