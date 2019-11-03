using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvents : Reducer {
    Dictionary <int, List<ReduxAction>> _actions;

    public override void init() {
        _actions = new Dictionary<int, List<ReduxAction>>();
    }


    public override void handleAction(ReduxAction action) {
        if (action.GetType() == typeof(AddTimedAction)) {
            GameDataManager manager = GameDataManager.GetInstance();

            AddTimedAction a = (AddTimedAction)action;
            int ticksUntil = a.GetTicksUntilAction();
            int currentTick = manager.GetCurrentTick();
            int tick = ticksUntil + currentTick;

            // ("Timed events handle add "+a.GetAction() + " at "+ tick);

            List<ReduxAction> actionsAtTime;

            if (_actions.ContainsKey(tick)){
                actionsAtTime = _actions[tick];
            }
            else {
                actionsAtTime = new List<ReduxAction>();
                _actions.Add(tick, actionsAtTime);
            }

            actionsAtTime.Add(a.GetAction());
        }
        else if (action.GetType() == typeof(TickAction)) {
            TickAction a = (TickAction)action;
            GameDataManager manager = GameDataManager.GetInstance();

            if (_actions.ContainsKey(a.GetTick())){
                List<ReduxAction> actionsAtTime= _actions[a.GetTick()];
                foreach(ReduxAction triggeredAction in actionsAtTime) {
                    manager.handleAction(triggeredAction);
                }
            }
        }
    }
}
