using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour
{
    public AudioSource audiosource;
    void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                {
                    audiosource.Play();
                }
        }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
