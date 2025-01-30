using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 6.0f;        // Movement speed
    public float gravity = -9.81f;   // Gravity force


    private CharacterController controller;
    private Vector3 velocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
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
