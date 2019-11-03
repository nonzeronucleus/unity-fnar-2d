using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class CharacterDisplayer : MonoBehaviour
{
     public StoriesHelper storiesHelper;

    public  static GameDataManager gameDataManager = GameDataManager.GetInstance();
    public Location location;
    public Enemy enemy;

    void Start()
    {
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
