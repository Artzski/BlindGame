using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundIntro : MonoBehaviour
{
    public AK.Wwise.Event playgroundIntro;

    // Start is called before the first frame update
    void Start()
    {
        playgroundIntro.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
