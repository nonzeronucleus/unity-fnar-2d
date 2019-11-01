using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvents : Reducer {
    Dictionary <int, List<Action>> _actions;

    public override void init() {
        _actions = new Dictionary<int, List<Action>>();
    }


    public override void handleAction(Action action) {
        if (action.GetType() == typeof(AddTimedAction)) {
            GameDataManager manager = GameDataManager.GetInstance();

            AddTimedAction a = (AddTimedAction)action;
            int ticksUntil = a.GetTicksUntilAction();
            int currentTick = manager.GetCurrentTick();
            int tick = ticksUntil + currentTick;

            // ("Timed events handle add "+a.GetAction() + " at "+ tick);

            List<Action> actionsAtTime;

            if (_actions.ContainsKey(tick)){
                actionsAtTime = _actions[tick];
            }
            else {
                actionsAtTime = new List<Action>();
                _actions.Add(tick, actionsAtTime);
            }

            actionsAtTime.Add(a.GetAction());
        }
        else if (action.GetType() == typeof(TickAction)) {
            TickAction a = (TickAction)action;
            GameDataManager manager = GameDataManager.GetInstance();

            if (_actions.ContainsKey(a.GetTick())){
                List<Action> actionsAtTime= _actions[a.GetTick()];
                foreach(Action triggeredAction in actionsAtTime) {
                    manager.handleAction(triggeredAction);
                }
            }
        }
    }
}
