using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class HandleCameraClick : MonoBehaviour
{
    public StoriesHelper storiesHelper;

    public string _locationName;
    public Location location;

    public void Start() {
        // _location = (Location)System.Enum.Parse(typeof(Location), _locationName);
    }


    void OnMouseDown() {
        storiesHelper.Dispatch(CCTVRoomStory.SelectCCTVRoonFactory.Get(location));

        // GameDataManager.GetInstance().handleAction(new RoomSelected(_location));
    }

}
