using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sisterToMainTP : MonoBehaviour
{
    private float timer = 80f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            SceneManager.LoadScene("PostSistersRoom", LoadSceneMode.Single);
        }
        timer = Mathf.Max(0, timer - Time.deltaTime);
    }
}
