using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeScroller : Scroller
{
    private Vector3 lastPanPosition = new Vector3(0, 0, -10);
    public float smoothTime = 0.1F;
    // public float maxSpeed = 7F;
    private Vector3 velocity = Vector3.zero;

    void scrollCamera(float targetX) {
        Vector3 current = GetComponent<Camera>().transform.position;

        Vector3 targetPosition = new Vector3(targetX, current.y, current.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    protected override void ScrollUpdate ()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if (y<0 || y>Screen.height) {
            return;
        }

        float width = Screen.width;

        if (x<(width/3)) {
            scrollCamera(minCamLeft);
        }
        else if (x<(2*width/3)) {
            scrollCamera(bgCentre);
        }
        else {
            scrollCamera(maxCamRight);
        }
    }
}
