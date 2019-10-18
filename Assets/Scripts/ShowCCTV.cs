using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShowCCTV : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Corridor", LoadSceneMode.Single);
    }
}
