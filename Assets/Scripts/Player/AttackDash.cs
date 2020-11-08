using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttackDash : MonoBehaviour
{
    public float ForcePower = 500f;
    public float SelfDamage = 15f;

    float dashDelayTime = 1f;
    bool canDash;
    Rigidbody body;
    CapsuleCollider attackCollider;
    Mover mover;
    Transform mainCamera;
    void Start()
    {
        canDash = true;
        body = GetComponent<Rigidbody>();
        attackCollider = transform.Find("DashAttackCapsule").GetComponent<CapsuleCollider>();
        mover = GetComponent<Mover>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            body.velocity = Vector3.zero;
            Vector3 moveDirection = mainCamera.forward.normalized;
            mover.StartMoving(moveDirection, ForcePower);

            Player.Instance.SetDamage(SelfDamage);
            StartCoroutine(DashDelay());
        }
    }
    IEnumerator DashDelay()
    {
        canDash = false;
        attackCollider.enabled = true;
        yield return new WaitForSeconds(dashDelayTime);
        attackCollider.enabled = false;
        canDash = true;
    }
}
