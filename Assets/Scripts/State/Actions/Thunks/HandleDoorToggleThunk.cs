using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoorToggle : Thunk
{
    private Door _door;
    public HandleDoorToggle(Door door) {
        _door = door;
    }

    public override void execute(GameDataManager manager){
        manager.handleAction(new ToggleDoorAction(_door,false));

        // Debug.Log("Executing HandleDoorToggle "+_door);
    }
}
