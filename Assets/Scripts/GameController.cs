using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static float count;
    static GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        gameData = GameData.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;
    }
}
