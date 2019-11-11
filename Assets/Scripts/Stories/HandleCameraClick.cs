using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class HandleCameraClick : MonoBehaviour
{
    public StoriesHelper storiesHelper;
    public Location location;

    public void OnMouseDown() {
        storiesHelper.Dispatch(CCTVRoomStory.SelectCCTVRoonFactory.Get(location));
    }
    public void OnClick() {
        storiesHelper.Dispatch(CCTVRoomStory.SelectCCTVRoonFactory.Get(location));
    }


}
