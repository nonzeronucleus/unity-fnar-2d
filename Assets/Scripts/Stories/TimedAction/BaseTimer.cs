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
    GameStateStory gameStateStory;


    void Start()
    {
        gameStateStory = storiesHelper.Get<GameStateStory>();

        if (!created) {
            created = true;
            storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(EnemyPositionStory.MoveCharacterFactory.Get(),2, true));
            storiesHelper.Dispatch(TimedActionsStory.AddTimedActiontFactory.Get(PowerStory.CalculateUsageFactory.Get(),1, true));
            storiesHelper.Dispatch(GameStateStory.SetGameStateFactory.Get(GameState.PLAYING));
        }
    }

    // // Update is called once per frame

    void Update()
    {
        if(gameStateStory.gameState == GameState.PLAYING) {
            count+=Time.deltaTime;

            if(count> nextTick) {
                storiesHelper.Dispatch(TimedActionsStory.TickFactory.Get());

                nextTick = count + tickInterval;
            }
        }
    }
}
