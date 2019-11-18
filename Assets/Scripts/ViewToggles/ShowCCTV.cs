using UnityEngine;
using UnityStories;

public class ShowCCTV : MonoBehaviour
{
    public StoriesHelper storiesHelper;

    public void OnClick()
    {
        storiesHelper.Dispatch(CameraStory.SwitchToCCTVFactory.Get());
    }

}
