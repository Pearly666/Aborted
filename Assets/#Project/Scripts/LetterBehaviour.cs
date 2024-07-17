using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterBehaviour : MonoBehaviour, IInteractable
{
    public static int papers;
    public static UnityEvent<int>onPickup = new();
    public void Interact()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Lettre ramassée");
        papers ++;
        onPickup?.Invoke(papers);
    }
}
