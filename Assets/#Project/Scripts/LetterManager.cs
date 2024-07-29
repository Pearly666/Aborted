using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


[System.Serializable]

public class Letter
{
    public string letterName;
    public AudioClip offvoice;
    public GameObject uiElement;
}
public class LetterManager : MonoBehaviour
{
     public List<Letter> lettersInOrder; // Ordre des lettres à lire
    [SerializeField]private List<string> collectedLetters = new List<string>(); // Lettres collectées
    [SerializeField]private int currentLetterIndex = 0;

    private AudioSource audioSource;
    private LetterUI letterUI;

    //Singleton
    public static LetterManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        letterUI = FindObjectOfType<LetterUI>();
        if (letterUI == null)
        {
            Debug.LogError("LetterUI not found in the scene. Make sure it is added to a GameObject.");
        }
    }

    public void CollectLetter(string letterName)
    {
        Debug.Log("Collecting letter: " + letterName);
        collectedLetters.Add(letterName);
        TryPlayNextLetter();
    }

    private void TryPlayNextLetter()
    {
        if (currentLetterIndex < lettersInOrder.Count)
        {
            Debug.Log("Playing audio and displaying UI for letter: " + lettersInOrder[currentLetterIndex].letterName);
            PlayLetterAudio(lettersInOrder[currentLetterIndex].offvoice);
            DisplayLetterUI(lettersInOrder[currentLetterIndex].uiElement);
            currentLetterIndex++;
        }
        else
        {
            Debug.Log("Letter not yet collected or no more letters to play.");
        }
    }

    private void PlayLetterAudio(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void DisplayLetterUI(GameObject uiElement)
    {
        if(letterUI != null)
        
        {
            letterUI.ShowLetterUI(uiElement);
        }
    }

}
