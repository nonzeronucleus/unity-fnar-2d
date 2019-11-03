using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thunk : ReduxAction
{
    // protected GameDataManager _manager = GameDataManager.GetInstance();

    public abstract void execute(GameDataManager manager);
}
