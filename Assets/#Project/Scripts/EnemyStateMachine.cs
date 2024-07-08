using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine
{
    public IState CurrentState { get; private set; }

    public ChaseState chaseState;
    public PatrolState patrolState;

    public EnemyStateMachine(NavMeshAgent agent, Transform playerTransform, Enemy enemy)
    {
        chaseState = new ChaseState(enemy, this);
        patrolState = new PatrolState(enemy, this);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState?.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }
}
