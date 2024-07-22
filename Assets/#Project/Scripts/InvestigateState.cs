using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InvestigateState : IState
{
    private NavMeshAgent agent;
    private Transform target;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;
    public Transform [] WayPoint;

    public InvestigateState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        agent = enemy.agent;
        target = enemy.target;
        WayPoint = enemy.WayPoint.GetComponentsInChildren<Transform>();
    }

    public void Enter()
    {
        Debug.Log("Investigation");
        GetToPlayerClosestPoint(WayPoint);
    }
    public bool IsAtDestination{
        get { return agent.remainingDistance <= agent.stoppingDistance; }
    }
    public void Update()
    {
        if (IsAtDestination)
        {
        stateMachine.TransitionTo(stateMachine.patrolState);
        }
        if (enemy.CanSeePlayer())
        {
            stateMachine.TransitionTo(stateMachine.chaseState);
        }
    }

    public void GetToPlayerClosestPoint(Transform[] Waypoint)
    {
        Transform bestPoint = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = target.transform.position;

        foreach(Transform potentialPoint in WayPoint)
        {   
            if(Mathf.Abs(potentialPoint.position.y - currentPosition.y) > 1.5f) continue;

            float distanceToPoint = Vector3.Distance(currentPosition, potentialPoint.position);
            if(distanceToPoint < closestDistance)
            {
                closestDistance = distanceToPoint;
                bestPoint = potentialPoint;
                agent.SetDestination(bestPoint.position);
            }
        }
        // if(bestTarget != null)
        // {
        //     agent.SetDestination(bestTarget.position);
        //     if (!enemy.CanSeePlayer())
        // {
        //     stateMachine.TransitionTo(stateMachine.patrolState);
        // }
        // }
    }
}
