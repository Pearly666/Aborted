using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]  

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] public float rayon;
    [SerializeField] float patrolTime = 15;

    [SerializeField] public Transform WayPoint;

    private EnemyStateMachine stateMachine;

    public bool isChasing
    {
        get { return stateMachine.chaseState.isChasing;}
        set { stateMachine.SetChasingState(value);}
    }

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        WayPoint = GameObject.FindWithTag("WayPoint").transform;

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(agent, target, this);
        stateMachine.Initialize(stateMachine.patrolState);
    }
    public bool CanSeePlayer()
    {
        Vector3 enemyFacing = transform.forward;
        Vector3 enemyPos = transform.position;
        Vector3 enemyToPlayer = target.position - enemyPos;
        Vector3 offset = Vector3.up*0.01f;

        RaycastHit hit;
        
        if (Physics.Raycast(enemyPos + offset,enemyToPlayer + offset, out hit,rayon))
        {
            if(hit.collider.CompareTag("Player"))
            {
                if(Vector3.Angle(enemyFacing, enemyToPlayer) <= 180f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    void Update()
    {
        stateMachine.Update();
        patrolTime -= Time.deltaTime;
        if(patrolTime < 0)
        {
            Spawner.noiseData = 0;
            Destroy(this.gameObject);
            Spawner.isInstantiated = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Salt"))
        {
            isChasing = false;
            Spawner.isInstantiated = false;
            Spawner.noiseData = 0;
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}