using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    public static bool readingLetter = false;
    public GameObject LetterCanva;
    public FirstPersonCamera fpsCamera;

    public void ShowLetterUI(GameObject uiElement)
{
    Debug.Log("ShowLetterUI called.");

    foreach (Transform child in LetterCanva.transform)
        {
            if (child.gameObject != uiElement)
            {
                child.gameObject.SetActive(false);
            }
        }

        
    if (uiElement != null)
    {
        uiElement.SetActive(true); // Afficher l'élément UI
        Debug.Log("UI Element " + uiElement.name + " activated.");
    }
    else
    {
        Debug.LogWarning("UI element is null.");
    }

    Time.timeScale = 0f;
    fpsCamera.enabled = false;
    readingLetter = true;
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
}
    public void BackToGame()
    {
        LetterCanva.SetActive(false);
        Time.timeScale = 1f;
        fpsCamera.enabled = true;;
        readingLetter = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
