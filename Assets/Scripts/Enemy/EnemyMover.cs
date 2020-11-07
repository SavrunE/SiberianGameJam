using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    public float DelayToAttack = 1f;
    EnemyAttack attack;
    Transform targetTransform;
    NavMeshAgent agent;
    
    float nearEnemyDistance;
    bool canAttack;

    public float StoppingDistance = 6f;
    void Start()
    {
        canAttack = true;
        targetTransform = Player.Instance.transform;

        attack = GetComponent<EnemyAttack>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nearEnemyDistance = Vector3.Distance(transform.position, targetTransform.position);

        if (nearEnemyDistance > StoppingDistance)
            Move();
        else
            Attacker();
    }
    private void Attacker()
    {
        if(canAttack)
        {
            canAttack = false;
            transform.LookAt(targetTransform.position);
            Attack();
            StartCoroutine(WaitPossibilityToAttack());
        }
    }
    IEnumerator WaitPossibilityToAttack()
    {
        yield return new WaitForSeconds(DelayToAttack);
        canAttack = true;
    }
    private void Move()
    {
        agent.SetDestination(targetTransform.position);
    }
    private void Attack()
    {
        attack.Boom();
    }
}