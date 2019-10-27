using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : Reducer
{
    public BaseState() {
        Debug.Log("Creating base state");

        AddChildReducer("Enemy Position", new EnemyPosition());
    }
}
