using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller : MonoBehaviour
{
    // float moveSpeed = 5.0f;
    SpriteRenderer background;
    protected Camera cam;
    protected float maxCamRight;
    protected float minCamLeft;
    protected float bgCentre;

    void Start()
    {
        background =  GameObject.Find("RoomBackground").GetComponent<SpriteRenderer>();
        cam = Camera.main;

        bgCentre = background.transform.position.x;
        float bgWidth = background.bounds.extents.x;
        float bgRight = bgCentre + bgWidth;
        float bgLeft = bgCentre - bgWidth;

        float camVertExtent = cam.orthographicSize;
        float camWidth = cam.aspect * camVertExtent;
        float camCentre = cam.transform.position.x;

        maxCamRight = bgRight - camWidth;
        minCamLeft = bgLeft + camWidth;
    }

}