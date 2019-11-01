using UnityEngine;

public class DoorState : Reducer
{
    Door _door;
    bool _isOpen;

    public DoorState(Door door) {
        _door=door;
        _isOpen = true;
    }

    public override string GetReducerName() {
        return GetType().ToString() + " " + _door.ToString();
    }


    public bool isOpen() {
        return _isOpen;
    }

    public override void handleAction(Action action) {
        if (action is ToggleDoorAction) {
            ToggleDoorAction a = (ToggleDoorAction)action;

            if (a.GetDoor() == _door) {
                Debug.Log("Toggling "+_door);
                _isOpen = a.isOpen();
            }
        }
    }


    // public void OpenDoor() {
    //     _isOpen = false;
    // }

    // public void CloseDoor() {
    //     _isOpen=false;
    // }
}
