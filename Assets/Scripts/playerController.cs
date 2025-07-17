using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 6.0f;        // Movement speed
    public float gravity = 1f;   // Gravity force

    public bool visitedSistersRoom = false;
    public bool visitedPlayground = false;
    //ak event for stopping the Voice Lines
    public AK.Wwise.Event idleStop;
    public AK.Wwise.Event footstepSound;
    public AK.Wwise.Event heartbeat;
    public AK.Wwise.Event playgroundFail;
    

    private float heartbeatTimer = 0.0f; // Timer for heartbeat sound
    private float footstepTimer = 0.0f;

    [SerializeField] private GameObject sister;
    [SerializeField] private GameObject markerHandler;

    //Attributes
    private CharacterController controller;
    private Vector3 velocity;
    public Rigidbody rb;
    public AK.Wwise.RTPC heartbeatVolume = null;
    private bool isCloseToEdge = false;

    void Start()
    {  
        heartbeat.Post(gameObject);
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rb.useGravity = true;
        rb.drag = 5f;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Respawn"))
        {
            playgroundFail.Post(sister);
            controller.enabled = false;
            this.transform.position = new Vector3(162, 2, 26);
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            velocity = Vector3.zero;
            controller.enabled = true;
            markerHandler.GetComponent<markerHandler>().PlaygroundReset();
        }
    }
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            velocity = Vector3.zero; // Reset velocity when paused
            return; // Do nothing if paused
        }
            

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Vector3 horizontalMove = new Vector3(move.x, 0, move.z);
        if (horizontalMove.magnitude > 0.01f && footstepTimer <= 0)
        {
            footstepSound.Post(gameObject);
            footstepTimer = 0.5f;
        }
        footstepTimer = Mathf.Max(0, footstepTimer - Time.deltaTime);

        // Handle heartbeat volume based on proximity to edges
        if (isCloseToEdge)
        {
            heartbeatTimer = Mathf.Min(heartbeatTimer + Time.deltaTime, 5); //max of 5 seconds for RTPC

        }
        else
        {
            heartbeatTimer = 0;
        }
        heartbeatVolume.SetValue(gameObject, heartbeatTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EdgeWarners"))
        {
            isCloseToEdge = true;
            heartbeatTimer = 1f;
        }
    }
    private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("EdgeWarners"))
            {
                isCloseToEdge = false;
            }
        }
}
