using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    
    [SerializeField] int toleratedNoise;
    static int noiseData = 0 ;
    private EnemyStateMachine stateMachine;
    static public bool isInstantiated = false ;
    public bool isTriggered = false;

    void OnTriggerEnter(Collider other)
        {
            if(isTriggered == false && other.CompareTag("Player"))
                {
                    noiseData += 2;
                    Debug.Log("noise is at " + noiseData);
                    isTriggered = true;
                }
            if(noiseData >= toleratedNoise && isInstantiated == false)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    Vector3 monsterPos = player.transform.position + player.transform.forward*5f;
                    noiseData = 0;
                    Instantiate(Enemy, monsterPos, transform.rotation);
                    isInstantiated = true;
                    //stateMachine.TransitionTo(stateMachine.chaseState);
                    
                }
        }
    
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }

    // void Update()
    // {
        
    // }
}