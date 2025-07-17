using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlindfoldRemover : MonoBehaviour
{
    public BlindfoldManager blindfoldManager;
    public GameObject player;
    void Start()
    {
        if (blindfoldManager == null)
        {
            blindfoldManager = GameObject.FindWithTag("Blindfold").GetComponent<BlindfoldManager>(); ;
            Debug.Log("Blindfold found:");
        }
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("Player found:");
        }
    }
    public void blindfoldToggle()
    {


        if (blindfoldManager.blindfold.activeSelf)
        {
            // The object is active
            blindfoldManager.blindfold.SetActive(false);
        }
        else
        {
            // The object is inactive
            blindfoldManager.blindfold.SetActive(true);
        }
    }
    public void closeGame()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        if(player != null && player.GetComponent<PauseMenu>() != null)
        { 
            Time.timeScale = 1f; // Resume the game
            PauseMenu.isPaused = false;
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Cursor.visible = false; // Hide the cursor
            SceneManager.UnloadSceneAsync("Menu"); // Unload the pause menu scene
        }
    }
}
