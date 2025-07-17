using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindfoldManager : MonoBehaviour
{
    public GameObject blindfold;
    void Start()
    {
        blindfold = GameObject.Find("Blindfold");
    }
}
