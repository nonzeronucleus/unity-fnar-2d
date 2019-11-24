using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;
using UnityEngine.UI;

public class GameStateTracker : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    Text textField;

    void Start()
    {
        textField = GetComponent<Text>();
        Debug.Log(textField);
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        GameStateStory gameStateStory = story.Get<GameStateStory>();

        switch(gameStateStory.gameState){
            case GameState.LOST:
                textField.text = "Game Lost";
                break;
            case GameState.WON:
                textField.text = "Game Won";
                break;
            default:
                textField.text = "";
                break;
        }
    }
}
