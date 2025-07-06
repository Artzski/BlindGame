using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 6.0f;        // Movement speed
    public float gravity = 1f;   // Gravity force

    //playground markers and voicelines
    [SerializeField] private GameObject[] markers;
    public bool visitedSistersRoom = false;
    public bool visitedPlayground = false;
    //ak event for stopping the Voice Lines
    public AK.Wwise.Event idleStop;

    private CharacterController controller;
    private Vector3 velocity;
    public Rigidbody rb;

    //Attributes

    public AK.Wwise.RTPC heartbeatVolume = null;

    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rb.useGravity = true;
        rb.drag = 5f;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn");
            controller.enabled = false;
            this.transform.position = new Vector3(162, 2, 26);
            velocity = Vector3.zero;
            controller.enabled = true;

            foreach (var m in markers)
            {
                if (m != null)
                {
                    m.SetActive(false);
                    idleStop.Post(m);
                }
            }


        }
    }
    void Update()
    {

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
