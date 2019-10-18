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

    void LateUpdate()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if (y<0 || y>Screen.height) {
            return;
        }

        float width = Screen.width;

        if (x<(width/3)) {
            scrollCamera(0-backgroundExtent);
        }
        else if (x<(2*width/3)) {
            scrollCamera(0);
        }
        else {
            scrollCamera(backgroundExtent);
        }
    }

    void OnGUI() {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        float width = Screen.width;

        string msg = string.Format("x:{0},y:{1},width:{2}, {3}", x,y,width, width/3, 32);

        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        guiStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(0,0,200,200),msg, guiStyle);
    }
}
