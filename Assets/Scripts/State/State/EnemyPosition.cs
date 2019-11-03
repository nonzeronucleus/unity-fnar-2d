using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : Reducer
{
    public Dictionary<Enemy, Location> enemyLocations = new Dictionary<Enemy, Location>();

    public override void init() {
        enemyLocations = new Dictionary<Enemy, Location>();
    }

    public override void handleAction(ReduxAction action) {
        if (action is EnemyMoved) {
            EnemyMoved a = (EnemyMoved)action;

            enemyLocations[a.GetEnemy()] = a.GetLocation();

            //_manager.handleAction(new AddTimedAction(new MoveEnemyThunk(), 5));
        }
    }

    public Dictionary<Enemy, Location> GetEnemyLocations() {
        return enemyLocations;
    }
}
