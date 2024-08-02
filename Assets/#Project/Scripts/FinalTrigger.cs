using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTrigger : MonoBehaviour
{
    public AudioSource scream;
    public bool screamPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scream.Play();
            LetterBehaviour.Reset();
            screamPlayed = true;
            
        }
    }

    void Update()
    {
        if (screamPlayed && !scream.isPlaying)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
