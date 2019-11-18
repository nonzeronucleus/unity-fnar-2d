using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStories;


[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/GameStateStory")]

public class GameStateStory : Story
{
    public StoriesHelper storiesHelper;

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

            if(newState==GameState.LOST) {
                story.storiesHelper.Dispatch(CameraStory.SwitchToOfficeFactory.Get());
            }
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
