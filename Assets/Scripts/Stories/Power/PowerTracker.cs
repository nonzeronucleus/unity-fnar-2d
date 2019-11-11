using UnityEngine;
using UnityEngine.UI;
using UnityStories;

public class PowerTracker : MonoBehaviour
{
    // public Slider slider;
    public Image fill;
     public StoriesHelper storiesHelper;
    // Start is called before the first frame update
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        PowerStory powerStory = story.Get<PowerStory>();
        int currentPower = powerStory.remainingPower;

        slider.value = currentPower;

        if(currentPower > 60) {
            fill.color = Color.green;
        }
        else if(currentPower > 20) {
            fill.color = Color.yellow;
        }
        else {
            fill.color = Color.red;
        }
    }
}
