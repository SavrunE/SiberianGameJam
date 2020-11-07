using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public float MoveSpeed;
    public float StartMoveVelocity = 10f;

    public float JumpPower;
    public KeyCode keyJump = KeyCode.Space;

    float moveHorizontal;
    float moveVertical;
    bool isGrounded;
    float velocity;
    Transform groundCheker;
    Vector3 movement;
    Vector3 moveDirection;
    Rigidbody body;

    void Start()
    {
        isGrounded = true;
        body = GetComponent<Rigidbody>();
        groundCheker = transform.Find("GroundChecker").GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        velocity = body.velocity.magnitude;

        Debug.Log(velocity);
        if (velocity < 10f)
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