using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbit : MonoBehaviour
{

    public Transform target;
    public float Distance = 0f;
    public float Sensitivity = 120f;
    public float YLimit = 5;
    private Rigidbody rigidbody;


    float x = 0.0f;
    float y = 0.0f;
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();
        
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * Sensitivity * 0.02f;

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        transform.rotation = rotation;
    }
}