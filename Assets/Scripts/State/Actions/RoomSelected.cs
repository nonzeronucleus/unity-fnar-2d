using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelected : Action
{
    Location _room;

    public RoomSelected(Location room) {
        _room = room;
    }

    public Location GetLocation() {
        return _room;
    }
}
