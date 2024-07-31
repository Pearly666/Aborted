using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioTrigger;
    public GameObject nextTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioTrigger.Play();
            nextTrigger.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !audioTrigger.isPlaying)
        {
            Destroy(this.gameObject);
        }
    } 
}
