using UnityEngine;
using UnityStories;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/CameraStory")]
public class CameraStory : Story
{
    public Location selectedCamera = Location.CorridorRight;

    public class SelectCamera : GenericAction<CameraStory, Location>
    {
        public override void Action(CameraStory story,Location location)
        {
            story.selectedCamera = location;
            SceneManager.LoadScene(location.ToString(), LoadSceneMode.Single);
        }
    }

    public class SwitchToCCTV : GenericAction<CameraStory>
    {
        public override void Action(CameraStory story)
        {
            SceneManager.LoadScene(story.selectedCamera.ToString(), LoadSceneMode.Single);

            // story.selectedCamera = location;
            // SceneManager.LoadScene(location.ToString(), LoadSceneMode.Single);
        }
    }

    public class SwitchToOffice : GenericAction<CameraStory>
    {
        public override void Action(CameraStory story)
        {
            SceneManager.LoadScene("Office", LoadSceneMode.Single);
            // story.selectedCamera = location;
            // SceneManager.LoadScene(location.ToString(), LoadSceneMode.Single);
        }
    }


    public static GenericFactory<SelectCamera, CameraStory, Location> SelectCameraFactory = new GenericFactory<SelectCamera, CameraStory, Location>();
    public static GenericFactory<SwitchToCCTV, CameraStory> SwitchToCCTVFactory = new GenericFactory<SwitchToCCTV, CameraStory>();
    public static GenericFactory<SwitchToOffice, CameraStory> SwitchToOfficeFactory = new GenericFactory<SwitchToOffice, CameraStory>();
}
