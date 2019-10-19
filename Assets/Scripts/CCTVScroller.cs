using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVScroller : Scroller
{
    Vector3 direction = Vector3.left;
    // public float time

    void LateUpdate () {
        float camPos = cam.transform.position.x;

        if (camPos < 0-backgroundExtent) {
            direction = Vector3.right;
        }
        else if (camPos > backgroundExtent) {
            direction = Vector3.left;
        }

        transform.Translate(direction * Time.deltaTime);
    }

    // Start is called before the first frame update

}
