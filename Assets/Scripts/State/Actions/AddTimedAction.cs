using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimedAction : Action
{
    Action _action;
    int _ticksUntilAction;
    public AddTimedAction(Action action, int ticksUntilAction) {
        _action = action;
        _ticksUntilAction = ticksUntilAction;
    }

    public Action GetAction () {
        return _action;
    }

    public int GetTicksUntilAction() {
        return _ticksUntilAction;
    }
}
