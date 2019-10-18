using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller : MonoBehaviour
{
    // float moveSpeed = 5.0f;
    SpriteRenderer background;
    protected Camera cam;
    protected float backgroundExtent;

    void Start()
    {
        background =  GameObject.Find("RoomBackground").GetComponent<SpriteRenderer>();
        cam = Camera.main;
        float camVertExtent = cam.orthographicSize;
        float camHorzExtent = cam.aspect * camVertExtent;

        float backgroundWidth = background.bounds.extents.x;
        backgroundExtent = backgroundWidth - camHorzExtent;
    }


    // Start is called before the first frame update

}