using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] public float rayon;
    [SerializeField] float patrolTime = 15;

    [SerializeField] public Transform WayPoint;
    public AudioSource enemySounds;

    private EnemyStateMachine stateMachine;
    private Animator enemyAnim;

    private bool playerIsDead = false;
    public AudioSource spawnScreamer;
    public PlayerControls playerControls;
    


    public bool isChasing
    {
        get { return stateMachine.chaseState.isChasing && Spawner.isInstantiated && ReactToMicrophone.isInstantiated; }
        //set { stateMachine.SetChasingState(value);}
    }

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        WayPoint = GameObject.FindWithTag("WayPoint").transform;
        enemySounds = GetComponent<AudioSource>();
        enemyAnim = GetComponent<Animator>();

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(agent, target, this);
        stateMachine.Initialize(stateMachine.patrolState);
        playerControls = FindAnyObjectByType<PlayerControls>();
    }

    void OnEnable()
    {
        spawnScreamer.Play();
    }
    public bool CanSeePlayer()
    {
        Vector3 enemyFacing = transform.forward;
        Vector3 enemyPos = transform.position;
        Vector3 enemyToPlayer = target.position - enemyPos;
        Vector3 offset = Vector3.up * 0.01f;

        RaycastHit hit;

        if (Physics.Raycast(enemyPos + offset, enemyToPlayer + offset, out hit, rayon))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (Vector3.Angle(enemyFacing, enemyToPlayer) <= 120f)
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
        if (patrolTime < 0)
        {
            Spawner.noiseData = 0;
            Destroy(this.gameObject);
            Spawner.isInstantiated = false;
        }
        if (playerIsDead)
            {
                Debug.Log("player is dead OK");
                PlayerKilled();
            }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"tag: {other.tag} - {other.name} - {other.transform.parent}");
        if (other.CompareTag("Salt"))
        {
            //isChasing = false;
            Spawner.isInstantiated = false;
            Spawner.noiseData = 0;
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Player"))
        {
            GameOver();

        }
    }

    void PlayerKilled()
    {
        if(!enemySounds.isPlaying){
            SceneManager.LoadScene("GameOver");
        }

    }

    void GameOver()
    {
        Debug.Log("Enemy is going to kill you");
        enemyAnim.SetBool("Attack", true);
        enemySounds.Play();
        playerIsDead = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        LetterManager.Reset();
        playerControls.enabled = false;
        //if(!enemySounds.isPlaying) SceneManager.LoadScene("GameOver");
            
    }


}