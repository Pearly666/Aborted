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

    [SerializeField] public Transform WayPoint;

    private EnemyStateMachine stateMachine;

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
                if(Vector3.Angle(enemyFacing, enemyToPlayer) <= 45f)
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
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Salt"))
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}