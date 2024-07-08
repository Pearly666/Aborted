using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState
{
    private NavMeshAgent agent;
    private Transform WayPoint;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;

    public PatrolState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        agent = enemy.agent;
        WayPoint = enemy.WayPoint;
    }
    public bool IsAtDestination{
        get { return agent.remainingDistance <= agent.stoppingDistance; }
    }
    private void SelectDestination()
    {
        int numWayPoint = WayPoint.childCount;
        int rndIndex = Random.Range(0, numWayPoint);
        Transform target = WayPoint.GetChild(rndIndex);
        agent.SetDestination(target.position);
    }

    public void Enter()
    {
        SelectDestination();
    }

    public void Update()
    {
        if (IsAtDestination)
        {
        SelectDestination();
        }
        if (enemy.CanSeePlayer())
        {
            stateMachine.TransitionTo(stateMachine.chaseState);
        }
    }
}
