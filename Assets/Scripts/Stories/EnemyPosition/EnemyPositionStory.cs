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
        SwitchesStory switchesStory = storiesHelper.Get<SwitchesStory>();

        if(switchesStory.doesLocationContainAvailableSwitch(currentLocation)) {
            Debug.Log("Has Switch");

            // TODO: 50% chance of swtiching toggle
        }



        DoorStory doorStory = storiesHelper.Get<DoorStory>();
        List<Location> exits = doorStory.GetExits(currentLocation);

        int numRooms = exits.Count;
        int roomIdx = Random.Range(0, numRooms);

        Location newLocation = (Location)exits[roomIdx];

        characterLocations[enemy]=newLocation;

        if (newLocation == Location.Office) {
            storiesHelper.Dispatch(GameStateStory.SetGameStateFactory.Get(GameState.LOST));
        }
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
