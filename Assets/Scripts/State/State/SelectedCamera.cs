using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectedCamera : Reducer
{
    Location _selectedCamera;

    public override void init() {
        _selectedCamera = Location.CorridorRight;
    }

    public override void handleAction(ReduxAction action) {
        if (action is RoomSelected) {
            RoomSelected a = (RoomSelected)action;

            _selectedCamera = a.GetLocation();

            SceneManager.LoadScene(_selectedCamera.ToString(), LoadSceneMode.Single);


            // GameDataManager.GetInstance().handleAction(new AddTimedAction(new MoveEnemyThunk(), 5));
        }
    }

    public Location GetSelectedCamera() {
        return _selectedCamera;
    }
}
