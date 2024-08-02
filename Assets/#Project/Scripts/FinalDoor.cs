using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DoorBehavior))]
public class FinalDoor : MonoBehaviour
{
    public PlayerInventory playerInventory;
    private DoorBehavior doorBehavior;
    public GameObject chains;
    public UnityEvent whenUnlocked;
    public AudioSource finalMusic;
    




    void Start()
    {
        doorBehavior = GetComponent<DoorBehavior>();
        doorBehavior.isLocked = true;
        
    }

    public void UnLock()
    {
            chains.SetActive(false);
            doorBehavior.isLocked = false;
            whenUnlocked?.Invoke();

            Debug.Log("Final door is opened");
        
    }
}
