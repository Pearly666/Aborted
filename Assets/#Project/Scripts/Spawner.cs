using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float timer = 3f;
    public GameObject Enemy;
    public int mobs = 0 ;
    void Start()
    {
        
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && mobs < 1)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            mobs += 1;
            timer = 3f;
        }
    }
}