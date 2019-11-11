using Unity;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/EnemyPositionStory")]
public class EnemyPositionStory : Story
{
    public StoriesHelper storiesHelper;

    public Dictionary<Enemy, Location> characterLocations= new Dictionary<Enemy, Location>();

    public override void InitStory()
    {
        characterLocations[Enemy.Porkie] = Location.CorridorRight;
        characterLocations[Enemy.Ginger] = Location.CorridorRight;
        characterLocations[Enemy.Merwing] = Location.CorridorRight;
        characterLocations[Enemy.Minty] = Location.HallRight;
        characterLocations[Enemy.Rainba] = Location.FusionCove;

    }

    public List<Enemy> EnemiesInLocation(Location location) {
        List<Enemy> enemies = new List<Enemy>();

        foreach(KeyValuePair<Enemy, Location> enemy in characterLocations) {
            if (enemy.Value == location) {
                enemies.Add(enemy.Key);
            }
        }

        return enemies;
    }

    void MoveCharacter(Enemy enemy) {
        Location currentLocation = characterLocations[enemy];
        DoorStory doorStory = storiesHelper.Get<DoorStory>();
        List<Location> exits = doorStory.GetExits(currentLocation);
        // string debugStr = currentLocation.ToString()+" [";


        // foreach(Location exit in exits) {
        //     debugStr += exit.ToString() + ",";
        // }

        // debugStr+="]";

        // Debug.Log(debugStr);

        int numRooms = exits.Count;
        int roomIdx = Random.Range(0, numRooms);

        Dictionary<Enemy, Location> newLocations= new Dictionary<Enemy, Location>();

        characterLocations[enemy]=(Location)exits[roomIdx];

        // Debug.Log("Moving "+ enemy + " to "+characterLocations[enemy]);
    }

    public class MoveCharacterAction : GenericAction<EnemyPositionStory>
    {
        public override void Action(EnemyPositionStory story)
        {
            int numEnemies = System.Enum.GetValues(typeof(Enemy)).Length;

            int enemyIdx = Random.Range(0, numEnemies);

            Enemy enemyToMove =  (Enemy)enemyIdx;
            story.MoveCharacter(enemyToMove);
        }
    }

    public static GenericFactory<MoveCharacterAction, EnemyPositionStory> MoveCharacterFactory = new GenericFactory<MoveCharacterAction, EnemyPositionStory>();
}
