using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    private float timeAlive;

    public float speed = 2F;

    public int maxTimeAlive = 10;

    const int SHARK_LENGTH = 5;
    const int GAME_WIDTH = 8;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > maxTimeAlive)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GAME_WIDTH + SHARK_LENGTH, transform.position.y), speed * Time.deltaTime);
        }
    }
}
