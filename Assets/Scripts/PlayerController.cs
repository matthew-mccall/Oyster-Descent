using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Texture[] frames;
    int framesPerSecond = 2;
    public float speed;
    Animator anime;
    float score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        GetComponent<SpriteRenderer>().material.mainTexture = frames[index];

        bool moved = false;


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            moved = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moved = true;
            transform.localScale = new Vector3(0.05F, 0.05F, 0.05F);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moved = true;
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moved = true;
            transform.localScale = new Vector3(0.05F, -0.05F, 0.05F);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        anime.enabled = moved;

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "shark" || collision.gameObject.tag == "crab" || collision.gameObject.tag == "scuba")
        {
            PlayerPrefs.SetInt("score", (int)score);

            if (score > PlayerPrefs.GetInt("highscore", -1))
            {
                PlayerPrefs.SetInt("highscore", (int)score);
            }

            SceneManager.LoadScene(2);
        }
    }
}
