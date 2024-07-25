using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip waterDrops;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(waterDrops);
        }
    }

}
