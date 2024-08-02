using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public FirstPersonCamera fpsCamera;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                BackToGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        fpsCamera.enabled = false;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void BackToGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        fpsCamera.enabled = true;;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadToMenu()
    {
        Time.timeScale = 1f;
        LetterManager.Reset();
        SceneManager.LoadScene("MainMenu");
    }
}
