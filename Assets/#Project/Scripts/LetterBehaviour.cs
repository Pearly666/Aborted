using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Lettre ramassée");
    }
}
