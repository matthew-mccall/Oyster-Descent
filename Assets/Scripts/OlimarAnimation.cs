using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlimarAnimation : MonoBehaviour
{
    public Texture[] frames;
    int framesPerSecond = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        GetComponent<SpriteRenderer>().material.mainTexture = frames[index];

    }
}
