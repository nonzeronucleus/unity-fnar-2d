using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemiesInRoom
{
    Reducer _state;

    public GetEnemiesInRoom(Reducer state) {
        _state = state;
    }
   public List<Enemy> Enemies(Location location) {
        List<Enemy> enemies = new List<Enemy>();

        EnemyPosition enemiesPosition = (EnemyPosition)_state.getItem("EnemyPosition");

        foreach(KeyValuePair<Enemy, Location> enemy in enemiesPosition.GetEnemyLocations()) {
            if (enemy.Value == location) {
                enemies.Add(enemy.Key);
            }
        }

        return enemies;
    }
}
