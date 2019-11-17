using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;
using UnityEngine.UI;

public class CharacterTracker : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public Enemy enemy;

    void Start()
    {
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        Dictionary<Enemy, Location> characterLocations= story.Get<EnemyPositionStory>().characterLocations;
        Text text = GetComponent<Text>();

        text.text = enemy.ToString() + ":" +characterLocations[enemy].ToString();
    }
}
