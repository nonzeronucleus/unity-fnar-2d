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
        characterLocations[Enemy.Rainba] = Location.HallLeft;

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

        int numRooms = exits.Count;
        int roomIdx = Random.Range(0, numRooms);

        Dictionary<Enemy, Location> newLocations= new Dictionary<Enemy, Location>();

        characterLocations[Enemy.Porkie]=(Location)exits[roomIdx];

        Debug.Log("Moving to "+characterLocations[Enemy.Porkie]);
    }

    public class MoveCharacterAction : GenericAction<EnemyPositionStory>
    {
        public override void Action(EnemyPositionStory story)
        {
            Enemy enemyToMove = Enemy.Porkie;
            story.MoveCharacter(enemyToMove);
        }
    }

    public static GenericFactory<MoveCharacterAction, EnemyPositionStory> MoveCharacterFactory = new GenericFactory<MoveCharacterAction, EnemyPositionStory>();
}
