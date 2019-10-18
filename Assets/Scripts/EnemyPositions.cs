using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositions : MonoBehaviour
{
    // Start is called before the first frame update
    static int count=0;
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(++count);
    }
}
