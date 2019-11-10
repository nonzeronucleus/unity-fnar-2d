using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVScroller : Scroller
{
    Vector3 direction = Vector3.left;
    // public float time

    void LateUpdate () {
        float camPos = cam.transform.position.x;

        if (camPos > maxCamRight) {
            direction = Vector3.left;
        }
        else if (camPos < minCamLeft) {
            direction = Vector3.right;
        }

        cam.transform.Translate(direction * Time.deltaTime *200);
    }

    void OnGUI() {
        float camPos = cam.transform.position.x;

        string msg = string.Format("x:{0}", camPos);

        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        guiStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(0,0,200,200),msg, guiStyle);
    }



    // Start is called before the first frame update

}
