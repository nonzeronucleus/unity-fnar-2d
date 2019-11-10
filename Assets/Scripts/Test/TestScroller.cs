using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScroller : MonoBehaviour
{
    void Start() {
        // Debug.Log(gameObject.transform.position.x);
    }

//     RectTransform background;
//     protected Camera cam;
//     protected float backgroundExtent;

//     void Start()
//     {
//         background =  GameObject.Find("RoomBackground").GetComponent<RectTransform>();
//         cam = Camera.main;
//         float camVertExtent = cam.orthographicSize;
//         float camHorzExtent = cam.aspect * camVertExtent;

//         float backgroundWidth = background.rect.width;

//         //background.bounds.extents.x;
//         backgroundExtent = backgroundWidth - camHorzExtent;
//     }


//    private Vector3 lastPanPosition = new Vector3(0, 0, -10);
//     public float smoothTime = 0.1F;
//     // public float maxSpeed = 7F;
//     private Vector3 velocity = Vector3.zero;

//     void scrollCamera(float targetX) {
//         Debug.Log(targetX);
//         Vector3 current = GetComponent<Camera>().transform.position;

//         Vector3 targetPosition = new Vector3(targetX, current.y, current.z);
//         transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
//     }

//     void LateUpdate()
//     {
//         float x = Input.mousePosition.x;
//         float y = Input.mousePosition.y;

//         if (y<0 || y>Screen.height) {
//             return;
//         }

//         float width = Screen.width;

//         if (x<(width/3)) {
//             scrollCamera(0-backgroundExtent);
//         }
//         else if (x<(2*width/3)) {
//             scrollCamera(0);
//         }
//         else {
//             scrollCamera(backgroundExtent);
//         }
//     }

//     void OnGUI() {
//         float x = Input.mousePosition.x;
//         float y = Input.mousePosition.y;

//         float width = Screen.width;

//         string msg = string.Format("x:{0},y:{1},width:{2}, {3}", x,y,width, width/3, 32);

//         GUIStyle guiStyle = new GUIStyle();
//         guiStyle.fontSize = 60;
//         guiStyle.normal.textColor = Color.white;

//         GUI.Label(new Rect(0,0,200,200),msg, guiStyle);
//     }


    // Start is called before the first frame update

    void OnGUI() {
        // float x = Input.mousePosition.x;
        // float y = Input.mousePosition.y;

        // float width = Screen.width;

        // string msg = string.Format("x:{0},y:{1},width:{2}, {3}", x,y,width, width/3, 32);

        // RectTransform background =  GameObject.Find("RoomBackground").GetComponent<RectTransform>();
        // ScrollRect rect = gameObject.GetComponent<ScrollRect>();
        // transform.position=new Vector2(1297,0);
        ScrollRect scrollRect = GameObject.Find("Scroller").GetComponent<ScrollRect>();

        Image image = gameObject.GetComponent<Image>();

        string msg = string.Format("x:{0}, width:{1}, scroll:{2}", transform.position.x, image.sprite.rect.width, scrollRect.content.rect.width);







        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        guiStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(0,0,200,200),msg, guiStyle);
    }


}