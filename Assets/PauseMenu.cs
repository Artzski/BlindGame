using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true;
            isPaused = true;
            Time.timeScale = 0f; // Pause the game
        }
    }
}
