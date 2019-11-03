using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/DoorStory")]
public class DoorStory : Story
{
    public Dictionary<Door, bool> isDoorOpen= new Dictionary<Door, bool>();
    public int test;

    public override void InitStory()
    {
        isDoorOpen[Door.Left] = false;
        isDoorOpen[Door.Right] = false;
    }


    public class ToggleDoor : GenericAction<DoorStory, Door>
    {
        public override void Action(DoorStory story,Door door)
        {
            story.isDoorOpen[door] = !story.isDoorOpen[door];
        }
    }

    public static GenericFactory<ToggleDoor, DoorStory, Door> ToggleDoorFactory = new GenericFactory<ToggleDoor, DoorStory, Door>();
}
