using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class markerHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] markers;
    [SerializeField] private GameObject currentMarker;
    private GameObject nextMarker;
    private int currentIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (markers.Length > 0)
        {
            for (int i = 0; i < markers.Length; i++)
                markers[i].SetActive(i == 0);
            currentMarker = markers[0];
            currentIndex = 0;
        }
    }

    public void OnMarkerTriggered(GameObject triggeredMarker)
    {
        Debug.Log("Marker Triggered: " + triggeredMarker.name);
        if ((currentMarker != null))
        {
            currentMarker.SetActive(false);
            currentIndex = (currentIndex + 1);
            nextMarker = markers[currentIndex];
            nextMarker.SetActive(true);
            currentMarker = nextMarker;
            // Post the voice line for the new marker
            AK.Wwise.Event voiceLine = nextMarker.GetComponent<AK.Wwise.Event>();
            if (voiceLine != null)
            {
                voiceLine.Post(nextMarker);
            }
        }

    }
}
