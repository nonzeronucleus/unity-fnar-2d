using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Sprite OpenDoor;
    public Sprite ClosedDoor;
    public bool isOpen = true;

    void OnMouseDown()
    {
        isOpen =! isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = isOpen ? OpenDoor : ClosedDoor;
    }
}
