using UnityEngine;

public class MoveEnemyThunk : Thunk
{
    public override void execute(GameDataManager manager){
        int numRooms = System.Enum.GetNames(typeof(Location)).Length;
        int roomIdx = Random.Range(0, numRooms);

        // enemyLocations[Enemy.Porkie] = (Location)roomIdx;


        manager.handleAction(new EnemyMoved(Enemy.Porkie,(Location)roomIdx));
//        Debug.Log("Executing Move Enemy Thunk");
    }
}
