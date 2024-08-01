using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction Movement;
    private CharacterController characterController;
    public AudioSource heartBeatAudioSource, chasedBeatAudioSource, ambiantNoise;
    
    private new Camera camera;
    private Vector3 forward, right;
    public bool isMoving { get; private set; }
    private Enemy enemy;

    [SerializeField] float walkSpeed;



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Movement = playerInput.actions["Movement"];
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
        heartBeatAudioSource.Play();
    }

    void Update()
    {
        Walk();

        if (enemy == null) enemy = FindObjectOfType<Enemy>();
        IsChased();

        if (PlayerInventory.hasKey)
        {
            heartBeatAudioSource.Stop();
            chasedBeatAudioSource.Stop();
            ambiantNoise.Stop();
        }
        
    }

    void Walk()
    {
        forward = camera.transform.forward;
        right = camera.transform.right;

        forward = Vector3.ProjectOnPlane(forward, Vector3.up);
        right = Vector3.ProjectOnPlane(right, Vector3.up).normalized;
        forward.Normalize();

        Vector2 movement = Movement.ReadValue<Vector2>();

        isMoving = movement != Vector2.zero;

        Vector3 finalMovement = movement.x * right + movement.y * forward;

        characterController.SimpleMove(finalMovement * walkSpeed);
    }
    void IsChased()
    {
        if(enemy != null && enemy.isChasing)
        {
            Debug.Log("Heartbeat should intensifies");
            heartBeatAudioSource.Stop();
            if (!chasedBeatAudioSource.isPlaying) chasedBeatAudioSource.Play();
        }
        else
        {
            chasedBeatAudioSource.Stop();
            if (!heartBeatAudioSource.isPlaying) heartBeatAudioSource.Play();
        }
    }
}
