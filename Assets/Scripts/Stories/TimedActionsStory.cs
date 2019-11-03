using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

public class TimeableAction {

    public TimeableAction(StoryAction action, int repeatTicks=0) {
        this.action=action;
        this.repeatTicks=repeatTicks;
    }
    public StoryAction action;
    public int repeatTicks;
}

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/TimedActionsStory")]

public class TimedActionsStory : Story
{
    public Dictionary <int, List<TimeableAction>> actions;
    public int currentTick;
    public StoriesHelper storiesHelper;

    public override void InitStory()
    {
         actions=new Dictionary <int, List<TimeableAction>>();
         currentTick = 0;
    }


    public void AddActionAtTick(int tick, TimeableAction actionAtTick) {
        List<TimeableAction> actionsAtTick;

        if (actions.ContainsKey(tick)){
            actionsAtTick = actions[tick];
        }
        else {
            actionsAtTick = new List<TimeableAction>();
            actions.Add(tick, actionsAtTick);
        }

        actionsAtTick.Add(actionAtTick);
}

    public class AddAction : GenericAction<TimedActionsStory, StoriesHelper , StoryAction, int, bool>
    {
        public override void Action(TimedActionsStory story, StoriesHelper storiesHelper, StoryAction action, int ticksUntil, bool repeat = false)
        {
            int tick = ticksUntil + story.currentTick;

            story.AddActionAtTick(tick, new TimeableAction(action, repeat ? ticksUntil : 0));
        }
    }

    public static GenericFactory<AddAction, TimedActionsStory, StoriesHelper, StoryAction, int, bool> AddTimedActiontFactory = new GenericFactory<AddAction, TimedActionsStory, StoriesHelper, StoryAction, int, bool>();

    public class TickAction: GenericAction<TimedActionsStory>
    {
        public override void Action(TimedActionsStory story)
        {
            story.currentTick++;
            if (story.actions.ContainsKey(story.currentTick)){
                List<TimeableAction> actionsAtTick = story.actions[story.currentTick];

                foreach(TimeableAction actionAtTick in actionsAtTick) {
                    story.storiesHelper.Dispatch(actionAtTick.action);
                    if(actionAtTick.repeatTicks > 0 ) {
                        story.AddActionAtTick(story.currentTick+actionAtTick.repeatTicks, actionAtTick);
                    }
                }
            }
        }
    }

    public static GenericFactory<TickAction, TimedActionsStory> TickFactory = new GenericFactory<TickAction, TimedActionsStory>();
}
