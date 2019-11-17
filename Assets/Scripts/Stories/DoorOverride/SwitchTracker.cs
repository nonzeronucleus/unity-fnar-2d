using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;



public class SwitchTracker : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public Sprite switchOnSprite;
    public Sprite switchOffSprite;
    public Location location;

    // public int switchId;

    // Start is called before the first frame update
    void Start()
    {
        location = transform.parent.GetComponent<SceneLocation>().location;

        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {

        SwitchesStory switchesStory = story.Get<SwitchesStory>();
        SwitchStory switchStory = switchesStory.GetStory(location);
        SwitchState state = switchStory.state;


        if (state == SwitchState.OFF) {
            gameObject.GetComponent<SpriteRenderer>().sprite = switchOffSprite;
        }
        else  {
            gameObject.GetComponent<SpriteRenderer>().sprite = switchOnSprite;
        }
        // SwitchStory switchStory =
        // Dictionary<Enemy, Location> characterLocations= story.Get<EnemyPositionStory>().characterLocations;
        // Text text = GetComponent<Text>();

        // text.text = enemy.ToString() + ":" +characterLocations[enemy].ToString();
    }
}
