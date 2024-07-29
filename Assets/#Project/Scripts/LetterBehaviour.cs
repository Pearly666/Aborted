using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterBehaviour : MonoBehaviour, IInteractable
{
    public static int papers;
    public static UnityEvent<int>onPickup = new();
    public string letterName;
    

    public void Interact()
    {
        
        Debug.Log("Lettre ramassée");
        LetterManager.Instance.CollectLetter(letterName);
        papers ++;
        onPickup?.Invoke(papers);
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
