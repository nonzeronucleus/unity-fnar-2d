using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShowOffice : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Office", LoadSceneMode.Single);
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Office", LoadSceneMode.Single);
    }
}
