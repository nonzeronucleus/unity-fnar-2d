using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class DoorHandler : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public Sprite OpenDoor;
    public Sprite ClosedDoor;
    public Door _door;

    void Start()
    {
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        bool isDoorOpen = story.Get<DoorStory>().isDoorOpen[_door];
        gameObject.GetComponent<SpriteRenderer>().sprite = isDoorOpen ? OpenDoor : ClosedDoor;
    }

    void OnMouseDown()
    {
        storiesHelper.Dispatch(DoorStory.ToggleDoorFactory.Get(_door));
    }
}
