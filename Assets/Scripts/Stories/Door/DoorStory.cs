using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/DoorStory")]
public class DoorStory : Story
{
    public StoriesHelper storiesHelper;

    public Dictionary<Door, bool> isDoorOpen= new Dictionary<Door, bool>();
    public Dictionary<Location, List<Location>> corridors = new Dictionary<Location, List<Location>>();

    public override void InitStory()
    {
        addCorridorLink(Location.CorridorLeft, Location.FusionCove);
        addCorridorLink(Location.CorridorLeft, Location.CorridorRight);
        addCorridorLink(Location.CorridorLeft, Location.HallLeft);
        addCorridorLink(Location.CorridorLeft, Location.DiningRoom);
        addCorridorLink(Location.CorridorRight, Location.DiningRoom);
        addCorridorLink(Location.CorridorRight, Location.HallRight);
        addCorridorLink(Location.CorridorRight, Location.Toilet);
        addCorridorLink(Location.DiningRoom, Location.Kitchen);
        addCorridorLink(Location.HallLeft, Location.DoorLeft);
        addCorridorLink(Location.HallRight, Location.DoorRight);

        isDoorOpen[Door.Left] = false;
        isDoorOpen[Door.Right] = true;
    }

    void addCorridor(Location from, Location to)
    {
        if (!corridors.ContainsKey(from)){
            corridors[from] = new List<Location>();
        }
        corridors[from].Add(to);
    }

    void addCorridorLink(Location a, Location b)
    {
        addCorridor(a,b);
        addCorridor(b,a);
    }


    public List<Location> GetExits(Location location){
        try {
            List<Location> exits = new List<Location>(corridors[location]);

            if(location == Location.DoorLeft && isDoorOpen[Door.Left]) {
                exits.Add(Location.Office);
            }
            else if(location == Location.DoorRight && isDoorOpen[Door.Right]) {
                exits.Add(Location.Office);
            }

            return exits;
        }
        catch(KeyNotFoundException e) {
            Debug.LogException(e);
            Debug.Log("Getting "+location);
            return new List<Location>();
        }
    }



    public int GetPowerUsage() {
        int powerUsage = 0;

        foreach(KeyValuePair<Door, bool>doorStatus in isDoorOpen) {
            bool isThisDoorOpen = doorStatus.Value;

            if (!isThisDoorOpen) {
                powerUsage++;
            }
        }
        return powerUsage;
    }

    // private void ToggleDoor(Door door) {
    //     PowerStory powerStory = storiesHelper.Get<PowerStory>();

    //     if(powerStory.remainingPower<=0) {
    //         return;
    //     }

    //     storiesHelper.Get<SwitchesStory>();

    //     isDoorOpen[door] = !isDoorOpen[door];
    // }


    private void OpenDoor(Door door) {
        isDoorOpen[door]=true;
    }

    private void TryToShutDoor(Door door){
        PowerStory powerStory = storiesHelper.Get<PowerStory>();
        SwitchesStory switchesStory = storiesHelper.Get<SwitchesStory>();

        // Door can't be closed if there's no power or the door lock switch is on
        if(powerStory.remainingPower<=0 || switchesStory.IsSwitchOn(door)) {
            return;
        }


        isDoorOpen[door]=false;
    }

    private void ToggleDoor(Door door) {
        if (isDoorOpen[door]) {
            TryToShutDoor(door);
        }
        else {
            OpenDoor(door);
        }
    }

    public class ToggleDoorAction : GenericAction<DoorStory, Door>
    {
        public override void Action(DoorStory story,Door door)
        {
            story.ToggleDoor(door);
        }
    }

    public static GenericFactory<ToggleDoorAction, DoorStory, Door> ToggleDoorFactory = new GenericFactory<ToggleDoorAction, DoorStory, Door>();

    public class OpenDoorsAction : GenericAction<DoorStory>
    {
        public override void Action(DoorStory story)
        {
            story.OpenDoor(Door.Left);
            story.OpenDoor(Door.Right);
        }
    }

    public static GenericFactory<OpenDoorsAction, DoorStory> OpenDoorsFactory = new GenericFactory<OpenDoorsAction, DoorStory>();

    public class OpensDoorAction : GenericAction<DoorStory, Door>
    {
        public override void Action(DoorStory story, Door door)
        {
            story.OpenDoor(door);
        }
    }

    public static GenericFactory<OpensDoorAction, DoorStory, Door> OpenDoorFactory = new GenericFactory<OpensDoorAction, DoorStory, Door>();

}
