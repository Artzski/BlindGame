using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class markerScript : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event voiceLine;
    public markerHandler handler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             handler.OnMarkerTriggered(this.gameObject);
        }
    }
}

