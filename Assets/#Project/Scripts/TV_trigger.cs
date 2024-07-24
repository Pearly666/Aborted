using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_trigger : MonoBehaviour
{
    public GameObject TVScreen;
    void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                {
                    TVScreen.SetActive(true);
                    Destroy(this.gameObject);
                }
        }
}
