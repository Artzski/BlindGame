using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playgroundMarkers : MonoBehaviour
{
    [SerializeField] private GameObject marker;
    public AK.Wwise.Event nextVoiceLine;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            marker.SetActive(true);
            nextVoiceLine.Post(marker);
        }
    }
}
