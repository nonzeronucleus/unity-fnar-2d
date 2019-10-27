using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : Reducer
{
    public Dictionary<Enemy, Location> enemyLocations = new Dictionary<Enemy, Location>();

    public override void init() {
        enemyLocations = new Dictionary<Enemy, Location>();
        Debug.Log("Enemy position handle init ");
    }

    public override void handleAction(Action action) {
        if (action is EnemyMoved) {
            EnemyMoved a = (EnemyMoved)action;

            enemyLocations[a.GetEnemy()] = a.GetLocation();

            Debug.Log("Enemy position handle action "+a.GetEnemy()+","+a.GetLocation());

            GameDataManager.GetInstance().handleAction(new AddTimedAction(new MoveEnemyThunk(), 5));
        }
    }

    public Dictionary<Enemy, Location> GetEnemyLocations() {
        return enemyLocations;
    }
}
