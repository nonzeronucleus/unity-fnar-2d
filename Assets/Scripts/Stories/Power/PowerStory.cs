using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/PowerStory")]
public class PowerStory : Story
{
    public int remainingPower = 100;
    public int currentUsage;
    public const int BASE_USAGE = 1;
    public StoriesHelper storiesHelper;

    public override void InitStory()
    {
        remainingPower = 100;
    }


    public void UpdatePower () {
        DoorStory doorStory = storiesHelper.Get<DoorStory>();
        currentUsage = BASE_USAGE + doorStory.GetPowerUsage();

        remainingPower = Math.Max(0, remainingPower - currentUsage);
        // Debug.Log(remainingPower);
    }

    public class CalculateUsage : GenericAction<PowerStory>
    {
        public override void Action(PowerStory story)
        {
            story.UpdatePower();
        }
    }

    public static GenericFactory<CalculateUsage, PowerStory> CalculateUsageFactory = new GenericFactory<CalculateUsage, PowerStory>();
}
