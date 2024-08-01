using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FillFromMicrophone : MonoBehaviour
{
    public Image audioBar;
    public Slider sensitivitySlider;
    public AudioLoudnessDetector detector;


    public float minimumSensitivity = 100;
    public float maximumSensitivity = 1000;
    public float currentLoudnessSensitivity;
    public float threshold = 0.1f;

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

        if (loudness > .5f) OnScreamDetected?.Invoke();

        if (loudness > .5f && !screamText.activeInHierarchy) screamText.SetActive(true);
        if (loudness <= .5f && screamText.activeInHierarchy) screamText.SetActive(false);
    }

    public void SetLoudnessSensitivity(float t)
    {
        currentLoudnessSensitivity = Mathf.Lerp(minimumSensitivity, maximumSensitivity, t);
    }

    
}
