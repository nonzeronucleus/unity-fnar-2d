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

    Reducer state = new BaseState();
    Selectors _selectors;

    int _currentTick = 0;

    public GameDataManager() {
    }

    public void init() {
        state.init();
        _selectors = new Selectors(state);

        Action a = new AddTimedAction(new MoveEnemyThunk(), 5);

        handleAction(a);
    }

    public void handleAction(Action action){
        state.handleAction(action);
    }

    public int GetCurrentTick() {
        return _currentTick;
    }

    public void Tick() {
        _currentTick++;

        Action a = new TickAction(_currentTick);

        handleAction(a);
    }

    public Selectors GetSelectors() {
        return _selectors;
    }
}
