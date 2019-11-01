using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameraClick : MonoBehaviour
{
    public string _locationName;
    private Location _location;

    public void Start() {
        _location = (Location)System.Enum.Parse(typeof(Location), _locationName);
    }


    void OnMouseDown() {
        GameDataManager.GetInstance().handleAction(new RoomSelected(_location));
    }

}
