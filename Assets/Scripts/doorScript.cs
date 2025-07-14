using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public GameObject door;
    public AK.Wwise.Event doorNoise;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(door);
            doorNoise.Post(gameObject);
        }
    }
}
