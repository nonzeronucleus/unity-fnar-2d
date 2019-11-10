using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/PowerStory")]
public class PowerStory : Story
{
    public int RemainingPower = 100;
    public int CurrentUsage = 0;

    public class CalculateUsage : GenericAction<PowerStory>
    {
        public override void Action(PowerStory story)
        {
        }
    }

    public static GenericFactory<CalculateUsage, PowerStory> CalculateUsageFactory = new GenericFactory<CalculateUsage, PowerStory>();
}
