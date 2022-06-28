using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{

    public GameObject crab;
    float timeLeft;
    public float spawnTime = 2;

    const int CRAB_LENGTH = 1;
    const int GAME_WIDTH = 8;
    const int GAME_HEIGHT = 5;

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
            GameObject go = GameObject.FindGameObjectWithTag("shark");
            if (go == null)
            {
                Instantiate(crab, new Vector3(-GAME_WIDTH - CRAB_LENGTH, Random.Range(-GAME_HEIGHT + CRAB_LENGTH, GAME_HEIGHT - CRAB_LENGTH)), transform.rotation);
            }
        }
    }
}
