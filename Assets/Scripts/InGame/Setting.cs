using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
    }

    public void title()
    {
        SceneManager.LoadScene("Title");
    }
}
