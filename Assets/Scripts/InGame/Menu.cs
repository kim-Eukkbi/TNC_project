using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;


    void Start()
    {
        menuPanel.SetActive(false);
    }

    public void OnMenu()
    {
        menuPanel.SetActive(true);
    }

    public void OffMenu()
    {
        menuPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void title()
    {
        SceneManager.LoadScene("Title");
    }
}
