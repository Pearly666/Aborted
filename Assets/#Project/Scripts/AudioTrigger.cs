using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioTrigger;
    public GameObject nextTrigger;
    public bool haveBeenPlayed = false;

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
        if (other.CompareTag("Player"))
        {
            haveBeenPlayed = true;
        }
    } 

    void Update()
    {
        if (haveBeenPlayed && !audioTrigger.isPlaying) Destroy(this.gameObject);
    }
}
