using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    public static bool readingLetter = false;
    public GameObject LetterCanva;
    public FirstPersonCamera fpsCamera;

    public void ShowLetterUI()
    {
        Debug.Log($"ShowLetterUI called. {name}");

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        Debug.Log("UI Element " + name + " activated.");

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
        fpsCamera.enabled = true; ;
        readingLetter = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
