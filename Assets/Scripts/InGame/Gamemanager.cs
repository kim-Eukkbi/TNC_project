using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void StartScene()
    {
        if(SceneManager.GetActiveScene().name.CompareTo("TITLE") != 0)
        {
            SceneManager.LoadScene("TITLE");
        }
    }
}
