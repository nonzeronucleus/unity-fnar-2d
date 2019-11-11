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

        // maxCamRight = bgRight - (camWidth);

        // Debug.Log("BG "+bgCentre+","+bgWidth+","+bgWidth/2+","+bgRight);
        // Debug.Log("Cam "+camCentre+","+camWidth+","+camWidth/2);
        // Debug.Log(maxCamRight+","+minCamLeft);



        // float camVertExtent = cam.orthographicSize;
        // float camHorzExtent = cam.aspect * camVertExtent;

        // float backgroundWidth = background.bounds.extents.x;
        // float offset = background.transform.position.x;

        // backgroundExtent = backgroundWidth - camHorzExtent;

        // Debug.Log(offset+","+backgroundWidth+","+camHorzExtent+","+ cam.transform.position.x);


        // leftMax = 0-offset/2;
        // rightMax = backgroundExtent - offset/2;
        // Debug.Log(leftMax+","+rightMax);
    }


    // Start is called before the first frame update

}