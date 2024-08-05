using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(MicrophoneSelector))]
public class FillFromMicrophone : MonoBehaviour
{
    public Image audioBar;
    public Slider sensitivitySlider;
    public AudioLoudnessDetector detector;


    public float minimumSensitivity = 10;
    public float maximumSensitivity = 100;
    public static float currentLoudnessSensitivity = 50;
    public static float threshold = 0.1f;

    public GameObject screamText;

    public static UnityAction OnScreamDetected;


    private void Start()
    {
        if (sensitivitySlider == null) return;
        
        sensitivitySlider.value = .5f;
        SetLoudnessSensitivity(sensitivitySlider.value);
    }

    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * currentLoudnessSensitivity;
        if (loudness < threshold) loudness = 0.01f;
        
        audioBar.fillAmount = loudness;
        Debug.Log(loudness);

        if (loudness > .5f) OnScreamDetected?.Invoke();

        if (loudness > .5f && !screamText.activeInHierarchy) screamText.SetActive(true);
        if (loudness <= .5f && screamText.activeInHierarchy) screamText.SetActive(false);
    }

    public void SetLoudnessSensitivity(float t)
    {
        currentLoudnessSensitivity = Mathf.Lerp(minimumSensitivity, maximumSensitivity, t);
    }

    
}
