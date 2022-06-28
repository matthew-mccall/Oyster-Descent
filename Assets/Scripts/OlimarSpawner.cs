using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlimarSpawner : MonoBehaviour
{

    public GameObject olimar;
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
            GameObject go = GameObject.FindGameObjectWithTag("olimar");
            if (go == null)
            {
                Instantiate(olimar, transform.position, transform.rotation);
            }
        }
    }
}
