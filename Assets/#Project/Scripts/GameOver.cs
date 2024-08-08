using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void BackToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
