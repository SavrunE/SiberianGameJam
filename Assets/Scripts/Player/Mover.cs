using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public Transform CameraPursure;

    public float MoveSpeed;
    public float StartMoveVelocity = 10f;
    public float MaxVelocity = 10f;



    float moveHorizontal;
    float moveVertical;
    float velocity;


    Transform mainCamera;
    Transform position;
    Vector3 movement;
    Vector3 moveDirection;
    Rigidbody body;

    void Start()
    {
        position = transform;
        body = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        position.rotation = CameraPursure.rotation;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = mainCamera.forward.normalized * moveVertical + mainCamera.right.normalized * moveHorizontal;

        velocity = body.velocity.magnitude;

        Debug.Log(velocity);
        if (velocity < MaxVelocity)
            StartMoving();
        else
            KeepMoving();

    }
    void StartMoving()
    { 
        body.AddForce(movement * MoveSpeed * StartMoveVelocity * Time.deltaTime, ForceMode.Impulse);
    }
    void KeepMoving()
    {
        body.AddForce(movement * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}