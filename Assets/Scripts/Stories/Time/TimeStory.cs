using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/TimeStory")]
public class TimeStory : Story
{
    private const string TimeFormat = "{0,1:D2}:{1,1:D2}";
    private const int MINS_IN_HOUR = 60;

    public StoriesHelper storiesHelper;
    protected int hour = 0;
    protected int min = 0;

    public override void InitStory(){
        hour = 0;
        min = 0;
    }

    public String GetTime() {
        return String.Format(TimeFormat, hour, min );
    }

    void UpdateTime() {
        ++min;

        if(min>= MINS_IN_HOUR) {
            min = 0;
            ++hour;
        }

        if(hour>=1) {
            storiesHelper.Dispatch(GameStateStory.SetGameStateFactory.Get(GameState.WON));
        }
    }


    public class UpdateTimeAction : GenericAction<TimeStory>
    {
        public override void Action(TimeStory story)
        {
            story.UpdateTime();
        }
    }

    public static GenericFactory<UpdateTimeAction, TimeStory> UpdateTimeFactory = new GenericFactory<UpdateTimeAction, TimeStory>();
}
