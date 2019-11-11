using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShowCCTV : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("CorridorRight", LoadSceneMode.Single);
    }

    public void OnClick()
    {
        SceneManager.LoadScene("CorridorRight", LoadSceneMode.Single);
    }

}
