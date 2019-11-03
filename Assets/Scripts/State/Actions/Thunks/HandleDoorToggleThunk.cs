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
        bool isDoorCurrentlyOpen = manager.GetSelectors().isDoorOpen(_door);

        manager.handleAction(new ToggleDoorAction(_door,!isDoorCurrentlyOpen));

        // Debug.Log("Executing HandleDoorToggle "+_door);
    }
}
