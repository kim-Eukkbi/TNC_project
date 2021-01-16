using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
/*    private void Start()
    {
        SceneManager.LoadScene("TITLE");
    }*/
    public void TitleScene()
    {
        SceneManager.LoadScene("MAIN");
    }
}
