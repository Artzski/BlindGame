using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject markerHandler;
    private bool afterPark = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        carNoiseStart.Post(gameObject);
        roadMarker2 = GameObject.Find("M2");
        if (roadMarker2 == null)
        {
            roadMarker2 = GameObject.Find("M4");
            afterPark = true;
        }
        markerHandler = GameObject.Find("Marker Handler");
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
            if (markerHandler != null)
            {
                markerHandler.GetComponent<markerHandler>().timer = 7f;
            }
            Debug.Log("crash");
            carNoiseStop.Post(gameObject);
            carScreech.Post(gameObject);

            playerDetected = true;
            tryAgain.Post(roadMarker2);
            if (afterPark)
            {
                other.gameObject.GetComponent<CharacterController>().enabled = false;
                other.gameObject.transform.position = new Vector3(-10f, 1.56f, -12f);
                other.gameObject.GetComponent<CharacterController>().enabled = true;
            }
            else //afterPark is false
            {
                other.gameObject.GetComponent<CharacterController>().enabled = false;
                other.gameObject.transform.position = new Vector3(1.23f, 1.56f, 10.83f);
                other.gameObject.GetComponent<CharacterController>().enabled = true;
            }
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
