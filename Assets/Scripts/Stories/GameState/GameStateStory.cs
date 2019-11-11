using UnityEngine;
using UnityEngine.UI;
using UnityStories;


[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/GameStateStory")]

public class GameStateStory : Story
{
    public GameState gameState = GameState.NOT_STARTED;

    // public class CalculateUsage : GenericAction<PowerStory>
    // {
    //     public override void Action(PowerStory story)
    //     {
    //     }
    // }

    // public static GenericFactory<CalculateUsage, PowerStory> CalculateUsageFactory = new GenericFactory<CalculateUsage, PowerStory>();
}

public enum GameState {
    NOT_STARTED,
    PLAYING,
    WON,
    LOST
}
