using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShowOffice : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Office", LoadSceneMode.Single);
    }
}
