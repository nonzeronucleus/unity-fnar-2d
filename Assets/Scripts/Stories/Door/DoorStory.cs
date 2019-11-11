using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/DoorStory")]
public class DoorStory : Story
{
    public Dictionary<Door, bool> isDoorOpen= new Dictionary<Door, bool>();

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

    public Dictionary<Location, List<Location>> corridors = new Dictionary<Location, List<Location>>();

    public List<Location> GetExits(Location location){
        try {
            List<Location> exits = new List<Location>(corridors[location]);

            if(location == Location.DoorLeft && isDoorOpen[Door.Left]) {
                exits.Add(Location.Office);
                Debug.Log(exits.ToString());
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


    public class ToggleDoor : GenericAction<DoorStory, Door>
    {
        public override void Action(DoorStory story,Door door)
        {
            story.isDoorOpen[door] = !story.isDoorOpen[door];
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

