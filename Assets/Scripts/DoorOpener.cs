using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public  static GameDataManager gameDataManager = GameDataManager.GetInstance();

    public Sprite OpenDoor;
    public Sprite ClosedDoor;
    public bool isOpen = true;
    public Door _door;

    void OnMouseDown()
    {
        GameDataManager.GetInstance().handleAction(new HandleDoorToggle(_door));
        // isOpen =! isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        bool isDoorOpen = gameDataManager.GetSelectors().isDoorOpen(_door);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = isDoorOpen ? OpenDoor : ClosedDoor;
    }
}
