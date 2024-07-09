using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        transform.GetComponent<Animator>().SetTrigger("Activate");
    }
}
