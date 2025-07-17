using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("PlaygroundTP"))
            {
                SceneManager.LoadScene("Playground");
            }
            if (this.gameObject.CompareTag("GoingHomeTP"))
            {
                SceneManager.LoadScene("GoingHome");
                other.gameObject.GetComponent<playerController>().visitedPlayground = true;
            }
            if (this.gameObject.CompareTag("EndingTP"))
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
