using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterMarkerScript : MonoBehaviour
{
    public AK.Wwise.Event voiceLine;
    [SerializeField] private GameObject marker;
    [SerializeField] private bool playedOnce = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        marker.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
