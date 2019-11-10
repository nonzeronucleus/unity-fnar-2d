using UnityEngine;
using UnityEngine.UI;
using UnityStories;

public class PowerTracker : MonoBehaviour
{
    public Slider slider;
     public StoriesHelper storiesHelper;
    // Start is called before the first frame update
    void Start()
    {
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        int currentPower = story.Get<PowerStory>().RemainingPower;

        slider.value = currentPower;

        // GetComponent<Renderer>().enabled=characterLocations[enemy]==location;
    }
}
