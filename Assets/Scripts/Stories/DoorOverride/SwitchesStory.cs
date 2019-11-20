using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/SwitchesStory")]
public class SwitchesStory : Story
{
    public StoriesHelper storiesHelper;

    protected Dictionary<Location, KeyValuePair<int, Door>> switchMap = new Dictionary<Location, KeyValuePair<int, Door>>();

    public override void InitStory()
    {
        switchMap.Add(Location.FusionCove, new KeyValuePair<int, Door>(0, Door.Left));
        switchMap.Add(Location.Kitchen, new KeyValuePair<int, Door>(1, Door.Right));
    }

    bool IsSwitchOff(Location location) {
        int switchId = switchMap[location].Key;
        SwitchStory switchStory = (SwitchStory)subStories[switchId];

        return switchStory.state == SwitchState.OFF;
    }

    public bool doesLocationContainAvailableSwitch (Location location) {
        return switchMap.ContainsKey(location) && IsSwitchOff(location);
    }

    public SwitchStory GetStory(Location location) {
        int switchId = switchMap[location].Key;
        return (SwitchStory)subStories[switchId];
    }

    public class ActivateSwitch : GenericAction<SwitchesStory, Location>
    {
        public override void Action(SwitchesStory story, Location location)
        {
            int switchId = story.switchMap[location].Key;
            Door doorToOpen = story.switchMap[location].Value;
            SwitchStory switchStory = (SwitchStory)story.subStories[switchId];

            Debug.Log("Activate Switch" + location+" for "+doorToOpen);

            switchStory.SetState(SwitchState.ON);

            // Todo: Open matching door when triggered
            story.storiesHelper.Dispatch(DoorStory.OpenDoorFactory.Get(doorToOpen));

            //AddTimedActiontFactory.Get(DectivateSwitchFactory.Get(location),20, false));

            story.storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(DectivateSwitchFactory.Get(location),20, false));
        }
    }

    public class DeactivateSwitch : GenericAction<SwitchesStory, Location>
    {
        public override void Action(SwitchesStory story, Location location)
        {
            int switchId = story.switchMap[location].Key;
            SwitchStory switchStory = (SwitchStory)story.subStories[switchId];

            switchStory.SetState(SwitchState.OFF);
        }
    }

    public static GenericFactory<ActivateSwitch, SwitchesStory, Location> ActivateSwitchFactory = new GenericFactory<ActivateSwitch, SwitchesStory, Location>();
    public static GenericFactory<DeactivateSwitch, SwitchesStory, Location> DectivateSwitchFactory = new GenericFactory<DeactivateSwitch, SwitchesStory, Location>();
}




