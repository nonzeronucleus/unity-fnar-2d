using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShowCCTV : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("CorridorRight", LoadSceneMode.Single);
    }
}
