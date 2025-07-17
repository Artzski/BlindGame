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
        blindfoldManager.blindfold.SetActive(!blindfoldManager.blindfold.activeSelf);
    }
    public void closeGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene("Main");
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
