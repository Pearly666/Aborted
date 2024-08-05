using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBehaviour : MonoBehaviour
{
    public GameObject saltParticle;
    public GameObject saltContainer;
    public AudioSource brokenGlass;
    public PickUpController pickUpController;
    

    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
        {
            Instantiate(saltParticle,transform.position, Quaternion.identity);
            brokenGlass.Play();
            pickUpController.enabled = false;
            
            //salt_particle.transform.position = transform.position;
            
        }
        }
}


