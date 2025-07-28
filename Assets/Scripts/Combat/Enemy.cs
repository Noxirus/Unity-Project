using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public enum EnemyAIState
{
    Idle,
    Patrol,
    Chase,
    Attack
}

public class Enemy : MonoBehaviour
{
    [Header("Enemy AI Details")]
    [SerializeField] private EnemyAIState currentState = EnemyAIState.Idle;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] GameObject currentTarget;
    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = 2f;
        _navMeshAgent.SetDestination(currentTarget.transform.position);
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyAIState.Idle:
                IdleBehavior();
                break;
            case EnemyAIState.Patrol:
                PatrolBehavior();
                break;
            case EnemyAIState.Chase:
                ChaseBehavior();
                break;
            case EnemyAIState.Attack:
                AttackBehavior();
                break;
        }
    }
    
    void IdleBehavior()
    {
        Debug.Log("Idling");
    }

    void PatrolBehavior()
    {
        Debug.Log("Patrolling");
    }

    void ChaseBehavior()
    {
        Debug.Log("Chasing");
        transform.position = Vector3.MoveTowards(
            transform.position, 
            currentTarget.transform.position, 
            chaseSpeed * Time.deltaTime
            );
        
        float currentDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
        if (currentDistance < attackDistance)
        {
            currentState = EnemyAIState.Attack;
        }
        
        // Move towards player
        // at X distance from player, enter attack sequence.
    }

    void AttackBehavior()
    {
        Debug.Log("Attacking");
        float currentDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
        if (currentDistance > attackDistance)
        {
            currentState = EnemyAIState.Chase;
        }
        // As long as the player is X distance, loop through attacking functionality
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyAIState.Chase;
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyAIState.Idle;
            currentTarget = null;
        }
    }
}
