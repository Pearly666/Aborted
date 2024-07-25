using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Interact : MonoBehaviour, IInteractable
{
    public GameObject TVScreen;
    public void Interact()
    {
        TVScreen.SetActive(false);
    }
}
