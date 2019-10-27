using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoved : Action
{
    Enemy _enemy;
    Location _location;
    public EnemyMoved(Enemy enemy, Location location) {
        _enemy=enemy;
        _location=location;
    }

    public Enemy GetEnemy() {
        return _enemy;
    }

    public Location GetLocation() {
        return _location;
    }
}
