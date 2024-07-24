using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TMP_Text inventoryLabel;
    public static int lastInventory;
    public static bool hasKey;

    void OnEnable()
    {
        LetterBehaviour.onPickup.AddListener(UpdateInventory);
        
    }

    void OnDisable()
    {
        LetterBehaviour.onPickup.RemoveListener(UpdateInventory);
    }


    void UpdateInventory(int value)
    {
        if (lastInventory != value)
        {
            inventoryLabel.SetText($"Letters: {value} / 10");
            lastInventory = value;
            if(lastInventory == 10){
                FindObjectOfType<KeyBehaviour>(includeInactive: true).gameObject.SetActive(true);
            }
        }
    }


}
