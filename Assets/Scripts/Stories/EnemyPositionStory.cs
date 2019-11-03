using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStories;

[CreateAssetMenu(menuName = "Unity Stories/FNAR2D/EnemyPositionStory")]
public class EnemyPositionStory : Story
{
    public Dictionary<Enemy, Location> characterLocations= new Dictionary<Enemy, Location>();
    public int test = 0;

    public override void InitStory()
    {
        characterLocations[Enemy.Porkie] = Location.CorridorRight;
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


    public class MoveCharacter : GenericAction<EnemyPositionStory>
    {
        public override void Action(EnemyPositionStory story)
        {
            int numRooms = System.Enum.GetNames(typeof(Location)).Length;
            int roomIdx = Random.Range(0, numRooms);

            Dictionary<Enemy, Location> newLocations= new Dictionary<Enemy, Location>();

            story.characterLocations[Enemy.Porkie]=(Location)roomIdx;

            Debug.Log("Moving to "+(Location)roomIdx);
        }
    }

    public static GenericFactory<MoveCharacter, EnemyPositionStory> MoveCharacterFactory = new GenericFactory<MoveCharacter, EnemyPositionStory>();
}
