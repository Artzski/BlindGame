using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 6.0f;        // Movement speed
    public float gravity = 1f;   // Gravity force


    private CharacterController controller;
    private Vector3 velocity;
    public Rigidbody rb;

    //Attributes

    public AK.Wwise.RTPC heartbeatVolume = null;

    void Start()
    {
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
            this.transform.position = new Vector3(172, 4, 26);
            velocity = Vector3.zero;
            controller.enabled = true;
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
