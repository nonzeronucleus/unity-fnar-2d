using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class CharacterDisplayer : MonoBehaviour
{
     public StoriesHelper storiesHelper;

    Location location;
    public Enemy enemy;

    void Start()
    {
        GameObject screen = GameObject.Find("GameScreen");

        location = screen.GetComponent<SceneLocation>().location;

        if(GetComponent<Renderer>() == null) {
            return;
        }

        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        Dictionary<Enemy, Location> characterLocations= story.Get<EnemyPositionStory>().characterLocations;

        GetComponent<Renderer>().enabled=characterLocations[enemy]==location;
    }
}
