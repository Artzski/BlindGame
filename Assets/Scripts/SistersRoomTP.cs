using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistersRoomTP : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject downstairsCollider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Save player position to PlayerPrefs
            Vector3 pos = collision.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", pos.x);
            PlayerPrefs.SetFloat("PlayerPosY", pos.y);
            PlayerPrefs.SetFloat("PlayerPosZ", pos.z);
            PlayerPrefs.Save();

            downstairsCollider.SetActive(false);
            // Load the SistersRoom scene
            collision.gameObject.GetComponent<playerController>().visitedSistersRoom = true;
            SceneManager.LoadScene("SistersRoom", LoadSceneMode.Single);
        }
    }
}
