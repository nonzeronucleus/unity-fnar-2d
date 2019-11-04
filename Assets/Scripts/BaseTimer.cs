using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class BaseTimer : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public static bool created = false;
    static float count;
    static float nextTick=0;
    [SerializeField] public const float tickInterval = 2;
    static Dictionary<string, Story> stories = new Dictionary<string, Story>();


    void Start()
    {
        if (!created) {
            created = true;
            storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(EnemyPositionStory.MoveCharacterFactory.Get(),2, true));
        }
    }




    // // Update is called once per frame

    void Update()
    {
        count+=Time.deltaTime;

        if(count> nextTick) {
            storiesHelper.Dispatch(TimedActionsStory.TickFactory.Get());

            nextTick = count + tickInterval;
        }
    }
}
