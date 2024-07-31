using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] AudioClip[] stepSounds;
    [SerializeField] AudioSource source;

    float timeBetweenSteps = 0.5f;
    float timer;

    [SerializeField] float minimumPitch;
    [SerializeField] float maximumPitch;

    void Update()
    {
        if (playerControls.isMoving && timer <= timeBetweenSteps)
        {
            timer += Time.deltaTime;
            if ( timer >= timeBetweenSteps)
            {
                timer = 0;
                PlayFootstepsSound();
            }
        }
    }

void PlayFootstepsSound()
{
    source.clip = stepSounds[Random.Range(0, stepSounds.Length)];
    source.pitch = Random.Range(minimumPitch, maximumPitch);
    source.Play();
}
}
