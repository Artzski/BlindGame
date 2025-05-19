using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playgroundMarkers : MonoBehaviour
{
    [SerializeField] private float idleVoiceTimer;
    [SerializeField] private GameObject marker;
    public AK.Wwise.Event nextVoiceLine;
    public AK.Wwise.Event idleLine;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            marker.SetActive(true);
            nextVoiceLine.Post(marker);
        }
    }
    private void Update()
    {
        if ((this.gameObject.activeSelf == true) && (idleVoiceTimer == 0))
        {
            idleLine.Post(gameObject);
            idleVoiceTimer = 5;
        }
        idleVoiceTimer = Mathf.Max(0, idleVoiceTimer - Time.deltaTime);
    }
}
