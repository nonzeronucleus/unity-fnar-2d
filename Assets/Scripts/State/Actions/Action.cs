using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    string _type;
    Object _payload;

    public Action(string type, Object payload) {
        _type = type;
        _payload = payload;
    }
    // Update is called once per frame
    public string getActionType()
    {
        return _type;
    }
}
