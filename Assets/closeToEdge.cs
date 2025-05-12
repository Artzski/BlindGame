using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeToEdge : MonoBehaviour
{
    [SerializeField] private float timer = 1;
    [SerializeField] private bool isCloseToEdge;
    [SerializeField] private GameObject player;
    private playerController playerControllerScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            playerControllerScript = player.GetComponent<playerController>();
            isCloseToEdge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            playerControllerScript = null;
            isCloseToEdge = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseToEdge)
        {
            timer = Mathf.Min(timer + Time.deltaTime, 5); //max of 5 seconds for RTPC

        }
        else
        {
            timer = 0;
        }
        if (player != null)
        {
            // Set the RTPC value based on the timer
           playerControllerScript.heartbeatVolume.SetValue(player, timer);
        }
        else { }
    }
}
