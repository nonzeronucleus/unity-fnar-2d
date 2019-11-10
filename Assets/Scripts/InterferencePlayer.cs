using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencePlayer : MonoBehaviour
{
    public Sprite[] frames;

    int framesPerSecond = 10;
    // int index = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int index = (int) (Time.time * framesPerSecond) % frames.Length;
        GetComponent<SpriteRenderer>().sprite = frames[index];

        //material.mainTexture = frames[index];

        // index = (index+1) % frames.Length;
    }
}
