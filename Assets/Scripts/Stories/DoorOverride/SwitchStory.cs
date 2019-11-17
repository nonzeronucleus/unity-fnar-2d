using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/SwitchStory")]
public class SwitchStory : Story
{
    public StoriesHelper storiesHelper;

    public SwitchState state;

    // Door triggeringDoor;

    // public SwitchStory( Door newTriggeringDoor) {
    //     triggeringDoor = newTriggeringDoor;
    // }

    public override void InitStory()
    {
        state = SwitchState.OFF;
    }

    public void SetState(SwitchState newState) {
        state = newState;
    }

    // public void CheckSetSwitchState()

    //     if (newState == SwitchState.ON) {
    //         TimedActionsStory timedActionsStory = storiesHelper.Get<TimedActionsStory>();

    //         storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(SwitchesStory..Get(),2, true));
    //     }
    // }

    // public void TurnOn() {
    //     state = SwitchState.ON;
    //     // TimedActionsStory timedActionsStory = storiesHelper.Get<TimedActionsStory>();

    //     // storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(SwitchesStory..Get(),2, true));

    // }

}
