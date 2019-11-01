using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : Reducer
{
    public BaseState() {
        AddChildReducer(new EnemyPosition());
        AddChildReducer(new TimedEvents());
        AddChildReducer(new SelectedCamera());
        AddChildReducer(new DoorState(Door.Left));
        AddChildReducer(new DoorState(Door.Right));
    }
}
