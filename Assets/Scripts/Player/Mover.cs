using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public Transform CameraPursure;

    public float MoveSpeed = 15f;
    public float StartMoveVelocity = 2f;
    public float MaxVelocity = 10f;

    float moveHorizontal;
    float moveVertical;
    float velocity;

    Transform mainCamera;
    Transform moverTransform;
    Vector3 moveDirection;
    Rigidbody body;
    ElectricitySphere overmovedSphere;

    void Start()
    {
        moverTransform = transform;
        overmovedSphere = GetComponent<ElectricitySphere>();
        body = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        moverTransform.rotation = CameraPursure.rotation;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        moveDirection = mainCamera.forward.normalized * moveVertical + mainCamera.right.normalized * moveHorizontal;
        velocity = body.velocity.magnitude;
        //Debug.Log(velocity);

        if (velocity < MaxVelocity)
            StartMoving();
        else
            KeepMoving();
    }
    void StartMoving()
    {
        overmovedSphere.Activate(false);
        body.AddForce(moveDirection * MoveSpeed * StartMoveVelocity * Time.deltaTime, ForceMode.Impulse);
    }
    void KeepMoving()
    {
        overmovedSphere.Activate(true);
        body.AddForce(moveDirection * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}