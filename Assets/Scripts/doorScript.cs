using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public GameObject door;
    public AK.Wwise.Event doorNoise;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
            doorNoise.Post(door);
            this.gameObject.SetActive(false);
        }
    }
}
