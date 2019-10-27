using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositions : GameData
{
    public Dictionary<Enemy, Location> enemyLocations = new Dictionary<Enemy, Location>();
    int numRooms = System.Enum.GetNames(typeof(Location)).Length;
    // public Dictionary<Location,List<Enemy>> enemiesInLocation = new Dictionary<Location,List<Enemy>>();

    public override void Start() {
        Debug.Log(numRooms);
        // enemyLocations.Add(Enemy.Porkie, Location.Corridor);
        // enemiesInLocation.Add(Location.Corridor, new List<Enemy>().Add(Enemy.Porkie));
    }


    public override void Tick() {
        int roomIdx = Random.Range(0, numRooms);

        enemyLocations[Enemy.Porkie] = (Location)roomIdx;
    }

    public List<Enemy> GetEnemiesInRoom(Location location) {

        List<Enemy> enemies = new List<Enemy>();

        foreach(KeyValuePair<Enemy, Location> enemy in enemyLocations) {
            if (enemy.Value == location) {
                enemies.Add(enemy.Key);
            }
        }

        return enemies;
    }
}
