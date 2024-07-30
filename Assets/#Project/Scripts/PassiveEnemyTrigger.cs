using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemyTrigger : MonoBehaviour
{
    public GameObject PassiveEnemy;
    public AudioSource audiosource;
    void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                {
                    PassiveEnemy.SetActive(true);
                    audiosource.Play();
                }
        }

}
