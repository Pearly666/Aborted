using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockingChairTrigger : MonoBehaviour
{
    [SerializeField] private Animator rockingChairController;
    public AudioSource audioSourceChair;
    [SerializeField] float stopDelay = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            rockingChairController.SetBool("playSwing", true);
            audioSourceChair.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            {
                Invoke("StopSound", stopDelay);
                // stopDelay += Time.deltaTime;
                // if(stopDelay >= 6)
                // {
                //     audioSourceChair.Stop();
                //     rockingChairController.SetBool("playSwing", false);
                // }
            }
    }

    void StopSound() {
        audioSourceChair.Stop();
        rockingChairController.SetBool("playSwing", false);
        Destroy(this.gameObject);
    }
}
