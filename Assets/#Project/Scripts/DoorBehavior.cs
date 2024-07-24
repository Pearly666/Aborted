using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorBehavior : MonoBehaviour, IInteractable
{
    public Animator doorAnimator;
    public bool isLocked = false;

    void Start(){
        if(doorAnimator == null){
            doorAnimator = GetComponentInChildren<Animator>();
        }
    }

    public bool isOpen = false;
    public void Interact()
    {   
        if(isLocked) return;

        if(doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpenTheDoor") || doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("CloseTheDoor")){
            return;
        }
        isOpen = !isOpen;

        doorAnimator.SetBool("close", !isOpen);
        doorAnimator.SetBool("open", isOpen);
    }
}
