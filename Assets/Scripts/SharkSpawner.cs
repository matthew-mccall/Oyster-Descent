using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{

    private float timeLeft;

    public GameObject shark;
    public float spawnTime = 20;

    const int SHARK_LENGTH = 5;
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

                int side = Random.Range(0, 3);
                int randX = Random.Range(-GAME_WIDTH - SHARK_LENGTH, GAME_WIDTH);
                int randY = Random.Range(-GAME_HEIGHT - SHARK_LENGTH, GAME_HEIGHT + SHARK_LENGTH);

                switch (side)
                {
                    case 0:
                        Instantiate(shark, new Vector3(randX, GAME_HEIGHT + SHARK_LENGTH), transform.rotation);
                        break;
                    case 1:
                        Instantiate(shark, new Vector3(-GAME_WIDTH - SHARK_LENGTH, randY), transform.rotation);
                        break;
                    case 2:
                        Instantiate(shark, new Vector3(randX, -GAME_HEIGHT - SHARK_LENGTH), transform.rotation);
                        break;
                    case 3:
                        Instantiate(shark, new Vector3(GAME_WIDTH + SHARK_LENGTH, randY), transform.rotation);
                        break;
                }
            }
            else
            {
                timeLeft = spawnTime;
            }
        }
    }
}
