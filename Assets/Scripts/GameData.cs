using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static GameData GetInstance () {
        if (self == null) {
            self = new GameData();
        }

        return self;
    }

    static GameData self;
}
