using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReactToMicrophone : MonoBehaviour
{
    //public Vector3 minScale, maxScale;
    public AudioLoudnessDetector detector;
    public float LoudnessSensitivity = FillFromMicrophone.currentLoudnessSensitivity;
    public float threshold = 0.01f;
    public GameObject Enemy;
    public static bool isInstantiated = false ;
    public static int noiseData = 0 ;

    void Start()
    {
        Debug.Log($"sensibilité: {FillFromMicrophone.currentLoudnessSensitivity}");
        Debug.Log($"microphone: {MicrophoneSelector.chosenDeviceIndex}");
    }
    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone()*LoudnessSensitivity;
        Debug.Log($"spawn {loudness > threshold}");
        Debug.Log($"loudness {loudness}");
        if (loudness > threshold && isInstantiated == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 monsterPos = player.transform.position + player.transform.forward*5f;
            noiseData = 0;
            Instantiate(Enemy, monsterPos, transform.rotation * Quaternion.Euler (0f, 180f, 0f));
            isInstantiated = true;
        }
        
        // loudness = 0;
        // gameObject.transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
