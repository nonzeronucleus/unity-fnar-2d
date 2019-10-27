using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    static float count;
    static float nextTick=0;
    [SerializeField] public const float tickInterval = 2;

   public  static GameDataManager gameDataManager;

    // Start is called before the first frame update
    GameController()
    {
        // count = 0;
        gameDataManager = GameDataManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;

        if(count> nextTick) {
            gameDataManager.Tick((int)Math.Round(count/tickInterval));

            nextTick = count + tickInterval;
        }
    }
}
