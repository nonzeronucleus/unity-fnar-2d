using UnityEngine;
using UnityEngine.UI;
using UnityStories;

public class TimeTracker : MonoBehaviour
{
     public StoriesHelper storiesHelper;
    // Start is called before the first frame update
    Text textField;
    void Start()
    {
        textField = GetComponent<Text>();
        storiesHelper.Setup(gameObject, MapStoriesToProps);
    }

	void MapStoriesToProps(Story story)
    {
        textField.text = "Mapped";
        TimeStory timeStory = story.Get<TimeStory>();

        textField.text = timeStory.GetTime();
        // PowerStory powerStory = story.Get<PowerStory>();
        // int currentPower = powerStory.remainingPower;

        // slider.value = currentPower;

        // if(currentPower > 60) {
        //     fill.color = Color.green;
        // }
        // else if(currentPower > 20) {
        //     fill.color = Color.yellow;
        // }
        // else {
        //     fill.color = Color.red;
        // }
    }
}
