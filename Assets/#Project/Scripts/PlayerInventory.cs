using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TMP_Text inventoryLabel;
    public static int lastInventory;
    private static bool _hasKey;

    public static bool hasKey
    {
        get { return _hasKey; }
        set
        {
            if (value)
            {
                FindObjectOfType<FinalDoor>().UnLock();
            }
            _hasKey = value;
        }
    }


    [SerializeField] private bool debug = false;


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
            if (debug || lastInventory == 10)
            {
                FindObjectOfType<KeyBehaviour>(includeInactive: true).gameObject.SetActive(true);
            }

        }
    }

    public static void Reset()
    {
        lastInventory = 0;
    }


}
