﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectors
{
    Reducer _state;

    public Selectors(Reducer state) {
        _state = state;
    }
   public List<Enemy> GetEnemiesInRoom(Location location) {
        List<Enemy> enemies = new List<Enemy>();

        EnemyPosition enemiesPosition = (EnemyPosition)_state.getItem("EnemyPosition");

        foreach(KeyValuePair<Enemy, Location> enemy in enemiesPosition.GetEnemyLocations()) {
            if (enemy.Value == location) {
                enemies.Add(enemy.Key);
            }
        }

        return enemies;
    }

    public bool isDoorOpen(Door door) {
        DoorState doorState= (DoorState)_state.getItem("DoorState " + door.ToString());
        return doorState.isOpen();
        // return false;
    }
}
