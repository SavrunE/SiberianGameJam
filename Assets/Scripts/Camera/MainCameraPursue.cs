using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraPursue : MonoBehaviour
{
    public Vector3 CameraPosition;

    [SerializeField] GameObject player;
    Transform cameraTransform;
    void Start()
    {
        cameraTransform = transform;
    }

    void Update()
    {
        cameraTransform.position = player.transform.position + CameraPosition;
    }
}
