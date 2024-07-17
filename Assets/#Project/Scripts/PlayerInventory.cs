using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TMP_Text inventoryLabel;
    int lastInventory;

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
        }
    }

}
