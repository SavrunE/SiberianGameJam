using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{

    Light light;
    void Start()
    {

        light = GetComponent<Light>();
        light.enabled = false;
    }

    public void ActivateLight(bool value)
    {
        if (value)
            light.enabled = true;
        else
            light.enabled = false;
    }
}
