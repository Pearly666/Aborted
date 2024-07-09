using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenForEnemy : MonoBehaviour
{
    private bool isTriggered = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && isTriggered == false)
        {
            transform.GetComponent<Animator>().SetTrigger("Activate");
            isTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && isTriggered == false)
        {
            transform.GetComponent<Animator>().SetTrigger("Activate");
            isTriggered = false;
        }
    }
}
