using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class ClickButtonToggle : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public void OnClickOn() {
        storiesHelper.Dispatch(SwitchesStory.ActivateSwitchFactory.Get(Location.FusionCove));

    }

    public void OnClickOff() {
        storiesHelper.Dispatch(SwitchesStory.DectivateSwitchFactory.Get(Location.FusionCove));

    }

}
