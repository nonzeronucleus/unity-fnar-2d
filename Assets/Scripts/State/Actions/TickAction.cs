using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickAction : Action
{
    int _tick;

    public TickAction(int tick) {
        _tick = tick;
    }

    public int GetTick() {
        return _tick;
    }
}
