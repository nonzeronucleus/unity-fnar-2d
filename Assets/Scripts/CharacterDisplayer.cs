using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplayer : MonoBehaviour
{
    public  static GameDataManager gameDataManager = GameDataManager.GetInstance();
    public string roomName;
    public Component PorkieImg;
    Location location;

    // Start is called before the first frame update
    void Start()
    {
        location = (Location)System.Enum.Parse(typeof(Location), roomName);
    }

    // Update is called once per frame
    void Update()
    {
        List<Enemy> enemiesInRoom = gameDataManager.GetSelectors().GetEnemiesInRoom(location);

        // GetComponent<Renderer>().enabled=false;

        PorkieImg.GetComponent<Renderer>().enabled=enemiesInRoom.Contains(Enemy.Porkie);

        // gameDataManager.
    }
}
