using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToMicrophone : MonoBehaviour
{
    //public Vector3 minScale, maxScale;
    public AudioLoudnessDetector detector;
    public float loudnessSensibility;
    public float threshold ;
    public GameObject Enemy;
    static public bool isInstantiated = false ;
    public static int noiseData = 0 ;

    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone()* loudnessSensibility;
        Debug.Log(loudness);
        if (loudness < threshold && isInstantiated == false)
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
