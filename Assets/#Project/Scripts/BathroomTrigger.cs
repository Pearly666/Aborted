using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

}
