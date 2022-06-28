using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject bubble;
    float timeLeft;
    public float spawnTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = spawnTime;
            GameObject go = GameObject.FindGameObjectWithTag("bubble");
            if (go == null)
            {
                Instantiate(bubble, transform.position, transform.rotation);
            }
        }
    }
}
