using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpPower;
    public KeyCode keyJump = KeyCode.Space;

    bool isGrounded;
    Transform groundCheker;
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
        Jump();
    }
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.AddForce(movement * MoveSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(keyJump))
        {
            if (isGrounded)
            {
                body.AddForce(Vector3.up * JumpPower);
                StartCoroutine(OnJumpWaiter());
            }
        }
    }
    IEnumerator OnJumpWaiter()
    {
        isGrounded = false;
        yield return new WaitForSeconds(0.5f);
        while(isGrounded == false)
        {
            CheckGround();
        }
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheker.position, 0.6f);

        isGrounded = colliders.Length > 1;
    }
}