using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement
    public Transform playerBody;         // Reference to the player body for horizontal rotation

    private float xRotation = 0f;        // To store vertical rotation (up/down)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate camera up/down (clamped to avoid flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player horizontally (yaw)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
