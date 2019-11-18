using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVScroller : Scroller
{
    Vector3 direction = Vector3.left;
    // public float time

    protected override void ScrollUpdate () {
        float camPos = cam.transform.position.x;

        if (camPos > maxCamRight) {
            direction = Vector3.left;
        }
        else if (camPos < minCamLeft) {
            direction = Vector3.right;
        }

        cam.transform.Translate(direction * Time.deltaTime *200);
    }
}
