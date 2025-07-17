using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    private Rigidbody rb;
    public AK.Wwise.Event carScreech;
    public AK.Wwise.Event carNoiseStart;
    public AK.Wwise.Event carNoiseStop;
    public AK.Wwise.Event tryAgain;
    public bool playerDetected = false;
    public GameObject roadMarker2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        carNoiseStart.Post(gameObject);
    }

    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
        if (playerDetected == true)
        {
            speed = 0f;
            Debug.Log("speed is 0");
        }
        if (playerDetected == false)
        {
            speed = 30f;
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("crash");
            carNoiseStop.Post(gameObject);
            carScreech.Post(gameObject);

            playerDetected = true;

            tryAgain.Post(roadMarker2);
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(1.23f, 1.56f, 10.83f);
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
        if (other.CompareTag("CarDespawnWall"))
        {
            Destroy(gameObject, 3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            carNoiseStart.Post(gameObject);
            playerDetected = false;
        }
    }
}
