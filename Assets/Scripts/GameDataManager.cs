using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    public static GameDataManager GetInstance () {
        if (self == null) {
            self = new GameDataManager();
        }
        return self;
    }

    static GameDataManager self;

    public List<GameData> data=new List<GameData>();
    Reducer state = new BaseState();

    EnemyPositions enemyPositions = new EnemyPositions();

    public GameDataManager() {
        data.Add(enemyPositions);
        state.init();

        data.ForEach(item => {
            item.Start();
        });
    }

    public EnemyPositions getEnemyPositions () {
        return enemyPositions;
    }




    public void Tick(int tick) {
        Action t = new Action("Test", null);

        state.handleAction(t);

        // Debug.Log(tick);
        data.ForEach(item => {
            item.Tick();
        });
    }
}
