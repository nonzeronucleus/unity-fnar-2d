using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/CCTVRoomStory")]
public class CCTVRoomStory : Story
{
    public Location selectedCamera = Location.CorridorRight;

    public class SelectCamera : GenericAction<CCTVRoomStory, Location>
    {
        public override void Action(CCTVRoomStory story,Location location)
        {
            story.selectedCamera = location;
            SceneManager.LoadScene(location.ToString(), LoadSceneMode.Single);
        }
    }

    public static GenericFactory<SelectCamera, CCTVRoomStory, Location> SelectCCTVRoonFactory = new GenericFactory<SelectCamera, CCTVRoomStory, Location>();
}
