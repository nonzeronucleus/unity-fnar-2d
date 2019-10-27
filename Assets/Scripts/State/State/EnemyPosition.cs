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
        Debug.Log("Enemy position handle action "+action.getActionType());
    }
}
