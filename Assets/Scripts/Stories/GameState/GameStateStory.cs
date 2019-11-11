using UnityEngine;
using UnityEngine.UI;
using UnityStories;


[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/GameStateStory")]

public class GameStateStory : Story
{
    public GameState gameState = GameState.NOT_STARTED;

    public override void InitStory()
    {
        gameState = GameState.NOT_STARTED;
    }


    public class SetGameState : GenericAction<GameStateStory, GameState>
    {
        public override void Action(GameStateStory story, GameState newState)
        {
            story.gameState = newState;
        }
    }

    public static GenericFactory<SetGameState, GameStateStory,GameState> SetGameStateFactory = new GenericFactory<SetGameState, GameStateStory,GameState>();
}

public enum GameState {
    NOT_STARTED,
    PLAYING,
    WON,
    LOST
}
