using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindfoldRemover : MonoBehaviour
{
    public GameObject blindfold;
    
    public void blindfoldToggle()
    {
        if (blindfold.activeSelf)
        {
            // The object is active
            blindfold.SetActive(false);
        }
        else
        {
            // The object is inactive
            blindfold.SetActive(true);
        }
    }
}
