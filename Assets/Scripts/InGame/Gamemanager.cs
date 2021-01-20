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

    [SerializeField]
    private GameObject chatPanel;
    [SerializeField]
    private GameObject scelectMain;

    private void Start()
    {
        if(!scelectMain.activeInHierarchy)
        {
            chatPanel.SetActive(false);
            scelectMain.SetActive(true);
        }
    }
}
