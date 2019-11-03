using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimedAction : ReduxAction
{
    ReduxAction _action;
    int _ticksUntilAction;
    public AddTimedAction(ReduxAction action, int ticksUntilAction) {
        _action = action;
        _ticksUntilAction = ticksUntilAction;
    }

    public ReduxAction GetAction () {
        return _action;
    }

    public int GetTicksUntilAction() {
        return _ticksUntilAction;
    }
}
