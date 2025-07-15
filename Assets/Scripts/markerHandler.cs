using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class markerHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] markers;
    [SerializeField] private GameObject currentMarker;
    [SerializeField] private AK.Wwise.Event idleLine;
    [SerializeField] private AK.Wwise.Event idleStop;
    private GameObject nextMarker;
    private int currentIndex = 0;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        timer = 15f;
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
        timer = 7f;
        Debug.Log("Marker Triggered: " + triggeredMarker.name);
        if ((currentMarker != null))
        {
            currentMarker.SetActive(false);
            currentIndex = (currentIndex + 1);
            nextMarker = markers[currentIndex];
            nextMarker.SetActive(true);
            currentMarker = nextMarker;
            // Post the voice line for the new marker
            AK.Wwise.Event voiceLine = currentMarker.GetComponent<markerScript>().voiceLine;
            if (voiceLine != null)
            {
                idleStop.Post(currentMarker);
                timer = 15f;
                voiceLine.Post(currentMarker);
            }
        }
    }

    private void Update()
    {
        if (currentMarker != null && timer <= 0)
        {
            idleLine.Post(currentMarker);
            timer = 10f;
        }
        timer = Mathf.Max(0, timer - Time.deltaTime);
    }
}
