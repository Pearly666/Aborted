using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(DoorBehavior))]
public class DoorOpenForEnemy : MonoBehaviour
{   
    private DoorBehavior door;

    void Start(){
        door = GetComponent<DoorBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")&& door.isOpen == false)
        {
            door.Interact();
        }
    }
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Enemy") && isOpen == true)
    //     {
    //         transform.GetComponent<Animator>().SetTrigger("Activate");
    //         isOpen = false;
    //     }
    // }
}
