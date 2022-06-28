using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{

    private float timeAlive;

    public float speed = 2F;

    private GameObject player;
    public int maxTimeAlive = 10;

    const int SHARK_LENGTH = 5;
    const int GAME_WIDTH = 8;
    const int GAME_HEIGHT = 5;

    int side = 0;
    int randX = 0;
    int randY = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > maxTimeAlive)
        {
            Destroy(gameObject);
        }
        else if (timeAlive > maxTimeAlive - 5)
        {
            if (side == 0)
            {
                side = Random.Range(0, 3);
                randX = Random.Range(-GAME_WIDTH - SHARK_LENGTH, GAME_WIDTH);
                randY = Random.Range(-GAME_HEIGHT - SHARK_LENGTH, GAME_HEIGHT + SHARK_LENGTH);
            }
            switch (side)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(randX, GAME_HEIGHT + SHARK_LENGTH), speed * Time.deltaTime);
                    break;
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(-GAME_WIDTH - SHARK_LENGTH, randY), speed * Time.deltaTime);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(randX, -GAME_HEIGHT - SHARK_LENGTH), speed * Time.deltaTime);
                    break;
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(GAME_WIDTH + SHARK_LENGTH, randY), speed * Time.deltaTime);
                    break;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.1F, 0.1F, 0.01F);
            }
            else
            {
                transform.localScale = new Vector3(0.1F, 0.1F, 0.01F);
            }
        }
    }
}
