using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindfoldManager : MonoBehaviour
{
    public static GameObject blindfold;
    void Start()
    {
        blindfold = GameObject.Find("Blindfold");
    }
}
