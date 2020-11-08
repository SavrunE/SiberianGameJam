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
    public float OverspeedRestoreEnergy= 1f;

    float moveHorizontal;
    float moveVertical;
    float velocity;

    Vector3 moveDirection;
    Transform mainCamera;
    Transform moverTransform;
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
            StartMoving(moveDirection, StartMoveVelocity);
        else
            KeepMoving();
    }
    public void StartMoving(Vector3 direction ,float boost)
    {
        overmovedSphere.Activate(false);
        body.AddForce(direction * MoveSpeed * boost * Time.deltaTime, ForceMode.Impulse);
    }
    void KeepMoving()
    {
        Player.Instance.RestoreDamage(OverspeedRestoreEnergy * Time.deltaTime);
        overmovedSphere.Activate(true);
        body.AddForce(moveDirection * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}