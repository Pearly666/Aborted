using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneScript : MonoBehaviour
{
    public AudioSource scream;
    void Update()
    {
        if (PlayerInventory.hasKey)
        {
            scream.Play();
        }

    }
}
