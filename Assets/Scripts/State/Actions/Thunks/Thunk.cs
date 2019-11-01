using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thunk : Action
{
    public abstract void execute(GameDataManager manager);
}
