public class ToggleDoorAction : Action
{
    Door _door;
    bool _isOpen;


    public ToggleDoorAction(Door door, bool isOpen) {
        _door = door;
        _isOpen = isOpen;
    }

    public Door GetDoor () {
        return _door;
    }

    public bool isOpen(){
        return _isOpen;
    }
}
