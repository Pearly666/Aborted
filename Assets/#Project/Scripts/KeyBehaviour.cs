using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour, IInteractable
{
    public  PlayerInventory playerInventory;

    void Start()
    {
        this.gameObject.SetActive(false);
    }


    public void Interact()
    {
        this.gameObject.SetActive(false);
        Debug.Log("clé ramassée");
        PlayerInventory.hasKey = true;
    }
}
