using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorBehavior : MonoBehaviour, IInteractable
{
    public Animator doorAnimator;

    void Start(){
        doorAnimator = GetComponentInChildren<Animator>();
    }

    public bool isOpen = false;
    public void Interact()
    {   

        if(doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpenTheDoor") || doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("CloseTheDoor")){
            return;
        }
        isOpen = !isOpen;

        doorAnimator.SetBool("close", !isOpen);
        doorAnimator.SetBool("open", isOpen);
    }
}
