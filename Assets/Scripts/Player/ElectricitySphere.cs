using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricitySphere : MonoBehaviour
{
    Light light;
    ParticleSystem sphereLight;
    void Start()
    {
        Transform electricitySphere = transform.Find("ElectricitySphere");
        sphereLight = electricitySphere.GetComponent<ParticleSystem>();
        light = electricitySphere.GetComponent<Light>();

        sphereLight.Stop();
        light.enabled = false;
    }
    public void Activate(bool value)
    {
        if (value)
        {
            sphereLight.Play();
            light.enabled = true;
        }
        else
        {
            sphereLight.Stop();
            light.enabled = false;
        }
    }
}
