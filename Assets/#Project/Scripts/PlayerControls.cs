using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction Movement;
    private CharacterController characterController;
    public AudioSource audioSource;
    public AudioClip chasedBeat;
    public AudioClip heartbeat;

    private new Camera camera;
    private Vector3 forward, right;
    public bool isMoving { get; private set; }
    private EnemyStateMachine stateMachine;

    [SerializeField] float walkSpeed;



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Movement = playerInput.actions["Movement"];
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
        audioSource.PlayOneShot(heartbeat);

    }

    void Update()
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

        //void IsChased();
        
    }

    // void IsChased()
    // {
    //     if(stateMachine.chaseState.isChasing == true)
    //     {
    //         audioSource.Stop();
    //         audioSource.PlayOneShot(chasedBeat);
    //     }
    //     if(stateMachine.chaseState.isChasing == false)
    //     {
    //         audioSource.Stop();
    //         audioSource.PlayOneShot(chasedBeat);
    //     }
    // }
}
