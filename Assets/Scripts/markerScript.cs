using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class markerScript : MonoBehaviour
{
    public AK.Wwise.Event voiceLine;
    public AK.Wwise.Event voiceLine2;
    public AK.Wwise.Event idleLine;
    [SerializeField] private GameObject marker;
    [SerializeField] private GameObject marker2;
    [SerializeField] private float idleVoiceTimer;
    [SerializeField] private AK.Wwise.Event idleLineStop;
    [SerializeField] private bool playedOnce = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Stop the idle voice line
            idleLineStop.Post(this.gameObject);
            if (playedOnce == false)
            {
                marker.SetActive(true);
                voiceLine.Post(marker);
                this.gameObject.SetActive(false);
                playedOnce = true;
            }
            else if (playedOnce == true)
            {
                marker2.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((marker.gameObject.activeSelf == true) && (idleVoiceTimer == 0))
        {
            idleLine.Post(marker);
            idleVoiceTimer = 5;
        }
        if ((marker2.gameObject.activeSelf == true) && (idleVoiceTimer == 0))
        {
            idleLine.Post(marker2);
            idleVoiceTimer = 5;
        }
        idleVoiceTimer = Mathf.Max(0, idleVoiceTimer - Time.deltaTime);
    }
}
