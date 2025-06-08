using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class markerScript : MonoBehaviour
{
    public AK.Wwise.Event voiceLine;
    public markerHandler handler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             handler.OnMarkerTriggered(this.gameObject);
        }
    }
}

