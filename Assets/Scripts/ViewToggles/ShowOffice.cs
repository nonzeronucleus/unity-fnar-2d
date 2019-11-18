using UnityEngine;
using UnityStories;


public class ShowOffice : MonoBehaviour
{
    public StoriesHelper storiesHelper;

    public void OnClick()
    {
        storiesHelper.Dispatch(CameraStory.SwitchToOfficeFactory.Get());
    }
}
