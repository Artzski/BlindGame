using AK.Wwise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterMarkerScript : MonoBehaviour
{
    public AK.Wwise.Event voiceLine;
    [SerializeField] private GameObject marker;
    [SerializeField] private GameObject markerHandler;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        marker.SetActive(true);
        markerHandler.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
