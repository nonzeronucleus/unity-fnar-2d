using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/DoorStory")]
public class DoorStory : Story
{
    DoorStory()
    {
        BaseTimer.RegisterStory("DoorStory", this);
    }

    public static void DumpToConsole(object obj)
    {
        var output = JsonUtility.ToJson(obj, false);
        Debug.Log(output);
    }

    public Dictionary<Door, bool> isDoorOpen= new Dictionary<Door, bool>();

    void addCorridor(Location from, Location to)
    {
        // corridors.Add(new Corridor(from, to));
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

    public Dictionary<Location, List<Location>> corridors = new Dictionary<Location, List<Location>>();

    public List<Location> GetExits(Location location){
        List<Location> exits = new List<Location>(corridors[location]);

        if(location == Location.HallLeft && isDoorOpen[Door.Left]) {
            exits.Add(Location.Office);
        }
        else if(location == Location.HallRight && isDoorOpen[Door.Right]) {
            exits.Add(Location.Office);
        }

        return exits;
    }


    public override void InitStory()
    {
        addCorridorLink(Location.CorridorLeft, Location.FusionCove);
        addCorridorLink(Location.CorridorLeft, Location.CorridorRight);
        addCorridorLink(Location.CorridorLeft, Location.FusionCove);
        addCorridorLink(Location.CorridorLeft, Location.HallLeft);
        addCorridorLink(Location.CorridorLeft, Location.DiningRoom);
        addCorridorLink(Location.CorridorRight, Location.DiningRoom);
        addCorridorLink(Location.CorridorRight, Location.HallRight);
        addCorridorLink(Location.CorridorRight, Location.Toilet);
        addCorridorLink(Location.DiningRoom, Location.Kitchen);
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


public class Corridor {

    Location from;
    Location to;

    public Corridor(Location from, Location to) {
        this.from = from;
        this.to = to;
    }
}

