using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;
    [SerializeField] private float timer;
    [SerializeField] private int randInt;
    void Start()
    {
        timer = 0;
        Instantiate(car, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            randInt = Random.Range(0, 400);
            if (randInt == 0)
            {
                Instantiate(car, transform.position, transform.rotation);
                timer = 1.5f;
            }
        }
        timer = Mathf.Max(0, timer - Time.deltaTime);
    }


}
