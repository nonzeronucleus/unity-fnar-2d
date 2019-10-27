using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    public static GameDataManager GetInstance () {
        if (self == null) {
            self = new GameDataManager();
            self.init();
        }

        return self;
    }

    static GameDataManager self;

    public List<GameData> data=new List<GameData>();
    Reducer state = new BaseState();

    EnemyPositions enemyPositions = new EnemyPositions();
    int _currentTick = 0;

    public GameDataManager() {
    }

    public void init() {
        data.Add(enemyPositions);

        state.init();
        Action a = new AddTimedAction(new MoveEnemyAction(), 5);

        state.handleAction(a);

        data.ForEach(item => {
            item.Start();
        });
    }

    public EnemyPositions getEnemyPositions () {
        return enemyPositions;
    }

    public void handleAction(Action action){
        // state.handleAction(action);
    }

    public int GetCurrentTick() {
        return _currentTick;
    }


    public void Tick() {
        _currentTick++;

    //     Action a = new TickAction(_currentTick);

    //     handleAction(a);

    //     // Debug.Log(tick);
        data.ForEach(item => {
            item.Tick();
        });
    }
}
