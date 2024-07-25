using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    private NavMeshAgent agent;
    private Transform target;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;
    public Transform [] WayPoint;
    public bool isChasing = false;

    public ChaseState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        agent = enemy.agent;
        target = enemy.target;
    }

    public void Enter()
    {
        Debug.Log("Entering ChaseState");
        isChasing = true;
    }

    public void Update()
    {
        agent.SetDestination(target.position);
        if (!enemy.CanSeePlayer())
        {
            stateMachine.TransitionTo(stateMachine.investigateState);
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting ChaseState");
        //audioSource.Stop();
        isChasing = false;
    }

}
